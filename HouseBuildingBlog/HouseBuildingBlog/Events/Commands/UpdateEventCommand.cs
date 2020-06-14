using HouseBuildingBlog.Api.Events.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Events.Commands
{
	public class UpdateEventCommand : IRequest<IActionResult>
	{
		public Guid EventId { get; }

		public EventCommandDto Data { get; }

		public UpdateEventCommand(Guid eventId, EventCommandDto data)
		{
			Data = data;
			EventId = eventId;
		}
	}
}
