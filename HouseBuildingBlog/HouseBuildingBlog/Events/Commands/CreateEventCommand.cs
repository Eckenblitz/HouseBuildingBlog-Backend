using HouseBuildingBlog.Events.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Events.Commands
{
	public class CreateEventCommand : IRequest<IActionResult>
	{
		public EventCommandDto Data { get; }

		public CreateEventCommand(EventCommandDto data)
		{
			this.Data = data;
		}
	}
}
