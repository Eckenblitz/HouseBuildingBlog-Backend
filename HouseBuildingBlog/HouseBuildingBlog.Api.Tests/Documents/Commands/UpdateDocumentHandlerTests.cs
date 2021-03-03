using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.TestBase.Documents;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Documents.Commands
{
	public class UpdateDocumentHandlerTests
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
				EventId = Guid.NewGuid(),
				TagIds = new List<Guid>() { Guid.NewGuid() }
			};

			var command = new UpdateDocumentCommand(documentId, data);
			var document = new TestDocument(documentId, command);
			_writeDocumentsAggregate.UpdateDocumentAsync(Arg.Is<Guid>(documentId), Arg.Any<IDocumentContent>()).Returns(document);

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			result.CheckResult<OkObjectResult, DocumentQueryDto>(d =>
				d.DocumentId == document.DocumentId
				&& d.Title == data.Title
				&& d.Comment == data.Comment
				&& d.EventId == data.EventId
				&& d.Price == data.Price
				&& d.TagIds.SequenceEqual(data.TagIds));
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
			_ = result.CheckResult<BadRequestObjectResult>();
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
			_ = result.CheckResult<NotFoundObjectResult>();
		}
	}
}
