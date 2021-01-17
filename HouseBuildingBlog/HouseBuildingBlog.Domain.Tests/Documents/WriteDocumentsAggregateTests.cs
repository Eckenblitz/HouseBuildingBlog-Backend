using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
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
		}

		[Fact]
		public async Task Expect_CreatedDocument_OnCreate()
		{
			//Arrange
			var content = new TestDocumentContent() { Title = "TestTitle", Comment = "TestComment", Price = 1.23M, EventId = Guid.NewGuid() };

			//Act
			var document = await SuT.CreateDocumentAsync(content);

			//Assert
			document.DocumentId.Should().NotBeEmpty();
			document.Title.Should().Be(content.Title);
			document.Comment.Should().Be(content.Comment);
			document.Price.Should().Be(content.Price);
			document.EventId.Should().Be(content.EventId);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("  ")]
		public async Task Expect_ValidationException_When_TitleIsEmpty_OnCreate(string? title)
		{
			//Arrange
			var content = new TestDocumentContent() { Title = title };

			//Act / Assert
			Func<Task<IDocument>> act = async () => await SuT.CreateDocumentAsync(content);
			var exception = (await act.Should().ThrowAsync<ValidationException>()).And;
			exception.ValidationErrors.Should().Contain(e => e.ErrorCode == DocumentErrorCodes.HasNoTitle);
		}

		[Fact]
		public async Task Expect_UpdatedDocument_OnUpdate()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentId)).Returns(new Document(documentId, new TestDocumentContent()));
			var newContent = new TestDocumentContent() { Title = "TestTitle", Comment = "TestComment", Price = 1.23M, EventId = Guid.NewGuid() };

			//Act
			var updatedDocument = await SuT.UpdateDocumentAsync(documentId, newContent);

			//Assert
			updatedDocument.DocumentId.Should().Be(documentId);
			updatedDocument.Title.Should().Be(newContent.Title);
			updatedDocument.Comment.Should().Be(newContent.Comment);
			updatedDocument.Price.Should().Be(newContent.Price);
			updatedDocument.EventId.Should().Be(newContent.EventId);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("  ")]
		public async Task Expect_ValidationException_When_TitleIsEmpty_OnUpdate(string? title)
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentId)).Returns(new Document(documentId, new TestDocumentContent()));
			var newContent = new TestDocumentContent() { Title = title };

			//Act / Assert
			Func<Task<IDocument>> act = async () => await SuT.UpdateDocumentAsync(documentId, newContent);
			var exception = (await act.Should().ThrowAsync<ValidationException>()).And;
			exception.ValidationErrors.Should().Contain(e => e.ErrorCode == DocumentErrorCodes.HasNoTitle);
		}

		[Fact]
		public async Task Expect_AggregateNotFoundException_WhenDocumentIsNotFound_OnUpdate()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentId)).Returns((IDocument)null);
			var newContent = new TestDocumentContent() { Title = "Test" };

			//Act / Assert
			Func<Task<IDocument>> act = async () => await SuT.UpdateDocumentAsync(documentId, newContent);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.DocumentNotFound);
		}

		[Fact]
		public async Task Expect_DeleteDocumentToBeCalled_When_DocumentIsDeleted()
		{
			//Arrange
			var documentId = Guid.NewGuid();

			//Act / Assert
			await SuT.DeleteDocumentAsync(documentId);

			//Assert
			_ = _writeDocumentsRepository.Received(1).DeleteDocumentAsync(Arg.Is(documentId));
		}


		[Fact]
		public async Task Expect_AggregateNotFoundException_WhenDocumentIsNotFound_OnDelete()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			_writeDocumentsRepository.GetByIdAsync(Arg.Is(documentId)).Returns((IDocument)null);

			//Act / Assert
			Func<Task<IDocument>> act = async () => await SuT.DeleteDocumentAsync(documentId);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.DocumentNotFound);
		}
	}
}
