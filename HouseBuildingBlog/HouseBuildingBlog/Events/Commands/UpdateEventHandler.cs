using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, IActionResult>
	{
		private readonly IWriteEventsAggregate _writeEventsAggregate;

		public UpdateEventHandler(IWriteEventsAggregate writeEventsAggregate)
		{
			_writeEventsAggregate = writeEventsAggregate;
		}

		public async Task<IActionResult> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
		{
			var @event = new Event(request.EventId, request.Data.Title, request.Data.Date);
			@event.UpdateDescription(request.Data.Description);
			@event.UpdateTags(request.Data.TagIds);

			var updatedEvent = await _writeEventsAggregate.UpdateEventAsync(@event);

			if (updatedEvent == null)
				return new NotFoundResult();

			return new OkObjectResult(new EventQueryDto(updatedEvent));
		}
	}
}
