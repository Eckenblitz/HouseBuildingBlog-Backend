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
	public class CreateDocumentHandlerTests
	{
		private CreateDocumentHandler SuT { get; }
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public CreateDocumentHandlerTests()
		{
			_writeDocumentsAggregate = Substitute.For<IWriteDocumentsAggregate>();
			SuT = new CreateDocumentHandler(_writeDocumentsAggregate);
		}

		[Fact]
		public async Task Expect_CreatedResult_When_CreatedSuccessfully()
		{
			//Arrange
			var data = new DocumentCommandDto()
			{
				Title = "Title",
				Comment = "Comment",
				Price = 1.23M,
				EventId = Guid.NewGuid(),
				TagIds = new List<Guid>() { Guid.NewGuid() }
			};

			var command = new CreateDocumentCommand(data);
			var document = new TestDocument(Guid.NewGuid(), command);
			_writeDocumentsAggregate.CreateDocumentAsync(Arg.Any<IDocumentContent>()).Returns(document);

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			result.CheckResult<CreatedResult, DocumentQueryDto>(d =>
				d.DocumentId == document.DocumentId
				&& d.Title == document.Title
				&& d.Comment == document.Comment
				&& d.EventId == document.EventId
				&& d.Price == document.Price
				&& d.TagIds.SequenceEqual(document.TagIds));
		}

		[Fact]
		public async Task Expect_BadRequestResult_When_ValidationFails()
		{
			//Arrange
			var command = new CreateDocumentCommand(new DocumentCommandDto());
			_writeDocumentsAggregate.CreateDocumentAsync(Arg.Any<IDocumentContent>())
				.Throws(new ValidationException(new List<DomainError>()));

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = result.CheckResult<BadRequestObjectResult>();
		}
	}
}
