using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Events.Commands
{
	public class DeleteEventCommand : IRequest<IActionResult>
	{
		public Guid EventId { get; }

		public DeleteEventCommand(Guid eventId)
		{
			this.EventId = eventId;
		}
	}
}
