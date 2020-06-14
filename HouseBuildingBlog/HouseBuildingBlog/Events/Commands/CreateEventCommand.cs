using HouseBuildingBlog.Api.Events.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Api.Events.Commands
{
	public class CreateEventCommand : IRequest<IActionResult>
	{
		public EventCommandDto Data { get; }

		public CreateEventCommand(EventCommandDto data)
		{
			Data = data;
		}
	}
}
