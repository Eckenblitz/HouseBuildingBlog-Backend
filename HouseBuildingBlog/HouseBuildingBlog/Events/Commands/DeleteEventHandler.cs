﻿using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, IActionResult>
	{
		private readonly IWriteEventsAggregate _writeEventsAggregate;

		public DeleteEventHandler(IWriteEventsAggregate writeEventsAggregate)
		{
			_writeEventsAggregate = writeEventsAggregate;
		}

		public async Task<IActionResult> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
		{
			var @event = await _writeEventsAggregate.DeleteEventAsync(request.EventId);

			if (@event == null)
				return new NotFoundResult();

			return new OkObjectResult(new EventQueryDto(@event));
		}
	}
}
