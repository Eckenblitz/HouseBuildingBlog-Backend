using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Documents.Commands
{
	public class UpdateDocumentHandlerTests : ActionResultTestBase
	{
		private UpdateDocumentHandler SuT { get; }
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public UpdateDocumentHandlerTests()
		{
			_writeDocumentsAggregate = Substitute.For<IWriteDocumentsAggregate>();
			SuT = new UpdateDocumentHandler(_writeDocumentsAggregate);
		}

		[Fact]
		public async Task Expect_OkResult_When_UpdatedSuccessfully()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var data = new DocumentCommandDto()
			{
				Title = "Title",
				Comment = "Comment",
				Price = 1.23M,
				EventId = Guid.NewGuid()
			};

			var command = new UpdateDocumentCommand(documentId, data);
			var document = new Document(documentId, command);
			_writeDocumentsAggregate.UpdateDocumentAsync(Arg.Is<Guid>(documentId), Arg.Any<IDocumentContent>()).Returns(document);

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			CheckResult<OkObjectResult, DocumentQueryDto>(result, d =>
				d.DocumentId == document.DocumentId
				&& d.Title == data.Title
				&& d.Comment == data.Comment
				&& d.EventId == data.EventId
				&& d.Price == data.Price);
		}

		[Fact]
		public async Task Expect_BadRequestResult_When_ValidationFails()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var command = new UpdateDocumentCommand(documentId, new DocumentCommandDto());
			_writeDocumentsAggregate.UpdateDocumentAsync(documentId, Arg.Any<IDocumentContent>())
				.Throws(new ValidationException(new List<DomainError>()));

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = CheckResult<BadRequestObjectResult>(result);
		}

		[Fact]
		public async Task Expect_NotFoundResult_When_DocumentCanNotBeFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var command = new UpdateDocumentCommand(documentId, new DocumentCommandDto());
			_writeDocumentsAggregate.UpdateDocumentAsync(documentId, Arg.Any<IDocumentContent>())
				.Throws(new AggregateNotFoundException("", documentId));

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = CheckResult<NotFoundObjectResult>(result);
		}
	}
}
