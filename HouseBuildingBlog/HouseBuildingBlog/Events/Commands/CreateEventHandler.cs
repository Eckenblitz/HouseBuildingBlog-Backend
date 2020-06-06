using HouseBuildingBlog.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class CreateEventHandler : IRequestHandler<CreateEventCommand, IActionResult>
	{
		private readonly IWriteEventsAggregate _writeEventsAggregate;

		public CreateEventHandler(IWriteEventsAggregate writeEventsAggregate)
		{
			_writeEventsAggregate = writeEventsAggregate;
		}

		public async Task<IActionResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			var @event = new Event(Guid.NewGuid(), request.Data.Title, request.Data.Date);
			@event.UpdateDescription(request.Data.Description);
			@event.UpdateTags(request.Data.TagIds);

			var createdEvent = await _writeEventsAggregate.CreateEventAsync(@event);

			return new CreatedResult(string.Empty, createdEvent);
		}
	}
}
