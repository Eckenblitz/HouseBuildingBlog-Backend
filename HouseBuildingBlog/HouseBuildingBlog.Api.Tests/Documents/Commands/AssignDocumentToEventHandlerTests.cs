using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.TestBase.Documents;
using HouseBuildingBlog.Domain.TestBase.Events;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Documents.Commands
{
	public class AssignDocumentToEventHandlerTests : ActionResultTestBase
	{
		private AssignDocumentToEventHandler SuT { get; }
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;
		private readonly IReadEventsAggregate _readEventsAggragate;

		public AssignDocumentToEventHandlerTests()
		{
			_writeDocumentsAggregate = Substitute.For<IWriteDocumentsAggregate>();
			_writeDocumentsAggregate.AssignEventAsync(Arg.Any<Guid>(), Arg.Any<Guid>())
				.Returns(args => new TestDocument() { DocumentId = args.ArgAt<Guid>(0), EventId = args.ArgAt<Guid>(1) });

			_readEventsAggragate = Substitute.For<IReadEventsAggregate>();
			_readEventsAggragate.GetAsync(Arg.Any<Guid>())
				.Returns(args => new TestEvent() { EventId = args.ArgAt<Guid>(0) });

			SuT = new AssignDocumentToEventHandler(_readEventsAggragate, _writeDocumentsAggregate);
		}

		[Fact]
		public async Task Expect_OkResult_When_AssignedSuccessfully()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var newEventId = Guid.NewGuid();
			var command = new AssignDocumentToEventCommand(documentId, newEventId);

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = _readEventsAggragate.Received(1).GetAsync(newEventId);
			_ = _writeDocumentsAggregate.Received(1).AssignEventAsync(documentId, newEventId);
			CheckResult<OkObjectResult, DocumentQueryDto>(result, d =>
				d.DocumentId == documentId
				&& d.EventId == newEventId);
		}

		[Fact]
		public async Task Expect_NotFound_When_EventIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var newEventId = Guid.NewGuid();
			var command = new AssignDocumentToEventCommand(documentId, newEventId);
			_readEventsAggragate.GetAsync(Arg.Is(newEventId)).Throws(new AggregateNotFoundException("", documentId));

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = CheckResult<NotFoundObjectResult>(result);
		}

		[Fact]
		public async Task Expect_NotFound_When_DocumentIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var newEventId = Guid.NewGuid();
			var command = new AssignDocumentToEventCommand(documentId, newEventId);
			_writeDocumentsAggregate.AssignEventAsync(Arg.Is(documentId), Arg.Is(newEventId)).Throws(new AggregateNotFoundException("", documentId));

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			_ = CheckResult<NotFoundObjectResult>(result);
		}
	}
}
