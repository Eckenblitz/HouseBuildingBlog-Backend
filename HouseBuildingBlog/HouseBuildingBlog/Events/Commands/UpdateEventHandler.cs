using HouseBuildingBlog.Api.Events.Models;
using HouseBuildingBlog.Api.Events.Queries.Contracts;
using HouseBuildingBlog.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Events.Commands
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
			var updatedEvent = await _writeEventsAggregate.UpdateEventAsync(new Event(request));

			if (updatedEvent == null)
				return new NotFoundResult();

			return new OkObjectResult(new EventQueryDto(updatedEvent));
		}
	}
}
