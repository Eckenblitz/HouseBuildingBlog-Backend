using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class AssignDocumentToEventHandler : IRequestHandler<AssignDocumentToEventCommand, IActionResult>
	{
		private readonly IReadEventsAggregate _readEventsAggregate;
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public AssignDocumentToEventHandler(IReadEventsAggregate readEventsAggregate, IWriteDocumentsAggregate writeDocumentsAggregate)
		{
			_readEventsAggregate = readEventsAggregate;
			_writeDocumentsAggregate = writeDocumentsAggregate;
		}

		public async Task<IActionResult> Handle(AssignDocumentToEventCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var @event = await _readEventsAggregate.GetAsync(request.EventId);
				//ToDo: should be thrown by the ReadEventsAggregate
				if (@event == null)
					throw new AggregateNotFoundException(EventErrorCodes.EventNotFound, request.EventId);

				var document = await _writeDocumentsAggregate.AssignEventAsync(request.DocumentId, request.EventId);

				return new OkObjectResult(new DocumentQueryDto(document));
			}
			catch (AggregateNotFoundException ex)
			{
				return new NotFoundObjectResult(ex.Error);
			}
			catch (ValidationException ex)
			{
				return new BadRequestObjectResult(ex.ValidationErrors);
			}
		}
	}
}
