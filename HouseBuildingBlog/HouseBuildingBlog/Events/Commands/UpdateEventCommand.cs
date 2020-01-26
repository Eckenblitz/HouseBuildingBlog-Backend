using HouseBuildingBlog.Events.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Events.Commands
{
	public class UpdateEventCommand : IRequest<IActionResult>
	{
		public Guid EventId { get; }

		public EventDto Data { get; }

		public UpdateEventCommand(System.Guid eventId, EventDto data)
		{
			Data = data;
			EventId = eventId;
		}
	}
}
