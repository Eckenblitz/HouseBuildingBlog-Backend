using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.Tests.Extensions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class ReadDocumentsAggregateTests
	{
		private readonly ReadDocumentsAggregate SuT;
		private readonly IReadDocumentsRepository _readDocumentsRepository;

		public ReadDocumentsAggregateTests()
		{
			_readDocumentsRepository = Substitute.For<IReadDocumentsRepository>();
			SuT = new ReadDocumentsAggregate(_readDocumentsRepository);
		}

		[Fact]
		public async Task Given_GetById_Expect_Document_When_DocumentExistInRepository()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var document = new TestDocument() { DocumentId = documentId, Title = "Title", Comment = "Comment", EventId = Guid.NewGuid(), Price = 1.23M };
			_readDocumentsRepository.GetByIdAsync(Arg.Is(documentId))
				.Returns(document);

			//Act
			var result = await SuT.GetByIdAsync(documentId);

			//Assert
			_ = _readDocumentsRepository.Received(1).GetByIdAsync(Arg.Is(documentId));
			result.Should().NotBeNull();
			result.DocumentId.Should().Be(document.DocumentId);
			result.CheckDocumentContent(document);
		}

		[Fact]
		public async Task Given_GetById_Expect_AggregateNotFoundException_When_DocumentIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var document = new TestDocument() { DocumentId = documentId };
			_readDocumentsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns((IDocument)null);

			//Act //Assert
			Func<Task<IDocument>> act = async () => await SuT.GetByIdAsync(documentId);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.DocumentNotFound);
			exception.Error.ErrorParameters["aggregateId"].Should().Be(documentId.ToString());
		}

		//GetAll
		[Fact]
		public async Task Given_GetAll_Expect_AllDocuments()
		{
			//Arrange
			var document1 = new TestDocument() { DocumentId = Guid.NewGuid() };
			var document2 = new TestDocument() { DocumentId = Guid.NewGuid() };
			_readDocumentsRepository.GetAllAsync().Returns(new List<IDocument>() { document1, document2 });

			//Act
			var documents = await SuT.GetAllAsync();

			//Assert
			_ = _readDocumentsRepository.Received(1).GetAllAsync();
			documents.Should().HaveCount(2);
			documents.Should().Contain(d => d.DocumentId.Equals(document1.DocumentId));
			documents.Should().Contain(d => d.DocumentId.Equals(document2.DocumentId));
		}

		[Fact]
		public async Task Given_DownloadFile_Expect_ReturnedFile()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var testFile = new TestDocumentFile()
			{
				DocumentId = documentId,
				FileName = "test.pdf",
				FileType = DocumentFileType.PDF,
				Binaries = TestDataCreator.CreateRandomBytes()
			};
			_readDocumentsRepository.GetByIdAsync(Arg.Is(documentId)).Returns(new TestDocument() { DocumentId = documentId });
			_readDocumentsRepository.GetFileAsync(Arg.Is(documentId)).Returns(testFile);

			//Act
			var file = await SuT.DownloadFile(documentId);

			//Assert
			_ = _readDocumentsRepository.Received(1).GetByIdAsync(Arg.Is(documentId));
			_ = _readDocumentsRepository.Received(1).GetFileAsync(Arg.Is(documentId));
			file.CheckDocumentFile(testFile);
		}

		[Fact]
		public async Task Given_DownloadFile_Expect_AggregateNotFoundException_When_DocumentIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_readDocumentsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns((IDocument)null);
			_readDocumentsRepository.GetFileAsync(Arg.Any<Guid>()).Returns(new TestDocumentFile());

			//Act //Assert
			Func<Task<IDocumentFile>> act = async () => await SuT.DownloadFile(documentId);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.DocumentNotFound);
			exception.Error.ErrorParameters["aggregateId"].Should().Be(documentId.ToString());
		}

		[Fact]
		public async Task Given_DownloadFile_Expect_AggregateNotFoundException_When_FileIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_readDocumentsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(new TestDocument());
			_readDocumentsRepository.GetFileAsync(Arg.Any<Guid>()).Returns((IDocumentFile)null);

			//Act //Assert
			Func<Task<IDocumentFile>> act = async () => await SuT.DownloadFile(documentId);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.FileNotFound);
			exception.Error.ErrorParameters["aggregateId"].Should().Be(documentId.ToString());
		}
	}
}
