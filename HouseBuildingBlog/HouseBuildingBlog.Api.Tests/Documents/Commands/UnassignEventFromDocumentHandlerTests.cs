using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.TestBase.Documents;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Documents.Commands
{
	public class UnassignEventFromDocumentHandlerTests
	{
		private UnassignEventFromDocumentHandler SuT { get; }
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public UnassignEventFromDocumentHandlerTests()
		{
			_writeDocumentsAggregate = Substitute.For<IWriteDocumentsAggregate>();
			_writeDocumentsAggregate.UnassignEventAsync(Arg.Any<Guid>())
				.Returns(args => new TestDocument() { DocumentId = args.ArgAt<Guid>(0), EventId = null });

			SuT = new UnassignEventFromDocumentHandler(_writeDocumentsAggregate);
		}

		[Fact]
		public async Task Expect_OkResult_When_UnassignedSuccessfully()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var command = new UnassignEventFromDocumentCommand(documentId);

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = _writeDocumentsAggregate.Received(1).UnassignEventAsync(documentId);
			result.CheckResult<OkObjectResult, DocumentQueryDto>(d =>
				d.DocumentId == documentId
				&& d.EventId == null);
		}

		[Fact]
		public async Task Expect_NotFound_When_DocumentIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var command = new UnassignEventFromDocumentCommand(documentId);
			_writeDocumentsAggregate.UnassignEventAsync(Arg.Is(documentId)).Throws(new AggregateNotFoundException("", documentId));

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = result.CheckResult<NotFoundObjectResult>();
		}
	}
}
