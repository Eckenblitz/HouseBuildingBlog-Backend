using HouseBuildingBlog.Events.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Events.Commands
{
	public class UpdateEventCommand : IRequest<IActionResult>
	{
		public Guid EventId { get; }

		public EventCommandDto Data { get; }

		public UpdateEventCommand(System.Guid eventId, EventCommandDto data)
		{
			Data = data;
			EventId = eventId;
		}
	}
}
