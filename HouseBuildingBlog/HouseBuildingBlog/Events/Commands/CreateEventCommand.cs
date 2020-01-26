using HouseBuildingBlog.Events.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Events.Commands
{
	public class CreateEventCommand : IRequest<IActionResult>
	{
		public EventDto Data { get; }

		public CreateEventCommand(EventDto data)
		{
			this.Data = data;
		}
	}
}
