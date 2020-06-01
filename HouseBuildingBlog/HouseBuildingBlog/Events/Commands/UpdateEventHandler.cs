using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
			@event.UpdateTags(request.Data.TagIds.Select(t => new Tag(t, string.Empty)));

			var updatedEvent = await _writeEventsAggregate.UpdateEventAsync(@event);

			if (updatedEvent == null)
				return new NotFoundResult();

			return new OkObjectResult(updatedEvent);
		}
	}
}
