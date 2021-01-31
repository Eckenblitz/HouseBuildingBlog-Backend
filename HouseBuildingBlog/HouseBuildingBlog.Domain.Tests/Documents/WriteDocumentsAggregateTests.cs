using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.Files;
using HouseBuildingBlog.Domain.TestBase.Documents;
using HouseBuildingBlog.Domain.Tests.Extensions;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class WriteDocumentsAggregateTests
	{
		private readonly WriteDocumentsAggregate SuT;
		private readonly IWriteDocumentsRepository _writeDocumentsRepository;

		public WriteDocumentsAggregateTests()
		{
			_writeDocumentsRepository = Substitute.For<IWriteDocumentsRepository>();
			SuT = new WriteDocumentsAggregate(_writeDocumentsRepository);

			_writeDocumentsRepository.CreateDocumentAsync(Arg.Any<IDocument>()).Returns(x => (IDocument)x[0]);
			_writeDocumentsRepository.UpdateDocumentAsync(Arg.Any<IDocument>()).Returns(x => (IDocument)x[0]);
			_writeDocumentsRepository.UploadFileAsync(Arg.Any<Guid>(), Arg.Any<IDocumentFile>()).Returns(x => (IDocumentFile)x[1]);
		}

		[Fact]
		public async Task Given_CreateDocument_Expect_CreatedDocument()
		{
			//Arrange
			var content = new TestDocumentContent() { Title = "TestTitle", Comment = "TestComment", Price = 1.23M, EventId = Guid.NewGuid() };

			//Act
			var document = await SuT.CreateDocumentAsync(content);

			//Assert
			_ = _writeDocumentsRepository.Received(1).CreateDocumentAsync(
				Arg.Is<IDocument>(d => d.DocumentId != Guid.Empty && d.HasDocumentExpectedContent(content)));
			document.DocumentId.Should().NotBeEmpty();
			document.CheckDocumentContent(content);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("  ")]
		public async Task Given_CreateDocument_Expect_ValidationException_When_TitleIsEmpty(string? title)
		{
			//Arrange
			var content = new TestDocumentContent() { Title = title };

			//Act / Assert
			Func<Task<IDocument>> act = async () => await SuT.CreateDocumentAsync(content);
			var exception = (await act.Should().ThrowAsync<ValidationException>()).And;
			exception.ValidationErrors.Should().Contain(e => e.ErrorCode == DocumentErrorCodes.HasNoTitle);
		}

		[Fact]
		public async Task Given_UpdateDocument_Expect_DocumentIsUpdated()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentId))
				.Returns(new TestDocument() { DocumentId = documentId });
			var newContent = new TestDocumentContent() { Title = "TestTitle", Comment = "TestComment", Price = 1.23M, EventId = Guid.NewGuid() };

			//Act
			var updatedDocument = await SuT.UpdateDocumentAsync(documentId, newContent);

			//Assert
			_ = _writeDocumentsRepository.Received(1).GetByIdAsync(Arg.Is(documentId));
			_ = _writeDocumentsRepository.Received(1).UpdateDocumentAsync(
				Arg.Is<IDocument>(d => d.DocumentId == documentId && d.HasDocumentExpectedContent(newContent)));
			updatedDocument.DocumentId.Should().Be(documentId);
			updatedDocument.CheckDocumentContent(newContent);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("  ")]
		public async Task Given_UpdateDocument_Expect_ValidationException_When_TitleIsEmpty(string? title)
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentId))
				.Returns(new TestDocument() { DocumentId = documentId });
			var newContent = new TestDocumentContent() { Title = title };

			//Act / Assert
			Func<Task<IDocument>> act = async () => await SuT.UpdateDocumentAsync(documentId, newContent);
			var exception = (await act.Should().ThrowAsync<ValidationException>()).And;
			exception.ValidationErrors.Should().Contain(e => e.ErrorCode == DocumentErrorCodes.HasNoTitle);
		}

		[Fact]
		public async Task Given_UpdateDocument_Expect_AggregateNotFoundException_WhenDocumentIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentId))
				.Returns((IDocument)null);
			var newContent = new TestDocumentContent() { Title = "Test" };

			//Act / Assert
			Func<Task<IDocument>> act = async () => await SuT.UpdateDocumentAsync(documentId, newContent);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.DocumentNotFound);
		}

		[Fact]
		public async Task Given_DeleteDocument_Expect_DeleteDocumentToBeCalled()
		{
			//Arrange
			var document = new TestDocument() { DocumentId = Guid.NewGuid() };
			_writeDocumentsRepository.DeleteDocumentAsync(Arg.Is(document.DocumentId)).Returns(document);

			//Act / Assert
			var deletedDocument = await SuT.DeleteDocumentAsync(document.DocumentId);

			//Assert
			_ = _writeDocumentsRepository.Received(1).GetByIdAsync(Arg.Is(document.DocumentId));
			_ = _writeDocumentsRepository.Received(1).DeleteDocumentAsync(Arg.Is(document.DocumentId));
			deletedDocument.DocumentId.Should().Be(document.DocumentId);
			deletedDocument.CheckDocumentContent(document);
		}


		[Fact]
		public async Task Given_DeleteDocument_Expect_AggregateNotFoundException_WhenDocumentIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentId))
				.Returns((IDocument)null);

			//Act / Assert
			Func<Task<IDocument>> act = async () => await SuT.DeleteDocumentAsync(documentId);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.DocumentNotFound);
		}

		[Fact]
		public async Task Given_UploadFile_Expect_DeleteDocumentToBeCalled()
		{
			//Arrange
			var documentFile = new TestDocumentFile()
			{
				DocumentId = Guid.NewGuid(),
				FileType = FileType.PDF,
				FileName = "FileName",
				Binaries = TestDataCreator.CreateRandomBytes()
			};

			//Act / Assert
			var uploadedFile = await SuT.UploadFileAsync(documentFile.DocumentId, documentFile);

			//Assert
			_ = _writeDocumentsRepository.Received(1).GetByIdAsync(Arg.Is(documentFile.DocumentId));
			_ = _writeDocumentsRepository.Received(1).UploadFileAsync(Arg.Is(documentFile.DocumentId), Arg.Is<IDocumentFile>(f => f.HasExpectedData(documentFile)));
			uploadedFile.CheckDocumentFile(documentFile);
		}


		[Fact]
		public async Task Given_UploadFile_Expect_AggregateNotFoundException_WhenDocumentIsNotFound()
		{
			//Arrange
			var documentFile = new TestDocumentFile()
			{
				DocumentId = Guid.NewGuid(),
				FileType = FileType.PDF,
				FileName = "FileName",
				Binaries = TestDataCreator.CreateRandomBytes()
			};
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentFile.DocumentId))
				.Returns((IDocument)null);

			//Act / Assert
			Func<Task<IDocumentFile>> act = async () => await SuT.UploadFileAsync(documentFile.DocumentId, documentFile);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.DocumentNotFound);
		}

		[Theory]
		[InlineData(FileType.PNG)]
		[InlineData(FileType.JPG)]
		public async Task Given_UploadFile_Expect_ValidationException_When_FileTypeIsInvalid(FileType fileType)
		{
			//Arrange
			var documentFile = new TestDocumentFile()
			{
				DocumentId = Guid.NewGuid(),
				FileType = fileType,
				FileName = "FileName",
				Binaries = TestDataCreator.CreateRandomBytes()
			};
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentFile.DocumentId))
				.Returns((IDocument)null);

			//Act / Assert
			Func<Task<IDocumentFile>> act = async () => await SuT.UploadFileAsync(documentFile.DocumentId, documentFile);
			var exception = (await act.Should().ThrowAsync<ValidationException>()).And;
			exception.ValidationErrors.Should().Contain(e => e.ErrorCode == DocumentErrorCodes.FileTypeNotAllowed);
		}
	}
}
