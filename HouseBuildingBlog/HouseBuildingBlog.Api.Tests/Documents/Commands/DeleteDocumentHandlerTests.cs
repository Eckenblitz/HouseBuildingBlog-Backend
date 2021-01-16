using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Queries;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Documents.Commands
{
	public class DeleteDocumentHandlerTests : ActionResultTestBase
	{
		private DeleteDocumentHandler SuT { get; }
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public DeleteDocumentHandlerTests()
		{
			_writeDocumentsAggregate = Substitute.For<IWriteDocumentsAggregate>();
			SuT = new DeleteDocumentHandler(_writeDocumentsAggregate);
		}

		[Fact]
		public async Task Expect_OkResultWithDeletedDocument_When_DocumentWasDeleted()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var document = new Document(documentId, new TestDocumentContent()
			{
				Title = "Title",
				Comment = "Comment",
				Price = 1.23M,
				EventId = Guid.NewGuid()
			});
			var command = new DeleteDocumentCommand(documentId);
			_writeDocumentsAggregate.DeleteDocumentAsync(Arg.Is<Guid>(documentId)).Returns(document);

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			CheckResult<OkObjectResult, DocumentQueryDto>(result, d =>
				d.DocumentId == document.DocumentId
				&& d.Title == document.Title
				&& d.Comment == document.Comment
				&& d.EventId == document.EventId
				&& d.Price == document.Price);
		}

		[Fact]
		public async Task Expect_NotFoundResult_When_DocumentCanNotBeFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var command = new DeleteDocumentCommand(documentId);
			_writeDocumentsAggregate.DeleteDocumentAsync(Arg.Is<Guid>(documentId))
				.Throws(new AggregateNotFoundException("", documentId));

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = CheckResult<NotFoundObjectResult>(result);
		}
	}
}
