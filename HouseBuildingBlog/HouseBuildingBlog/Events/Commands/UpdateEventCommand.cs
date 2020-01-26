using HouseBuildingBlog.Events.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Events.Commands
{
	public class UpdateEventCommand : IRequest<IActionResult>
	{
		public EventDto Data { get; }

		public UpdateEventCommand(EventDto data)
		{
			Data = data;
		}
	}
}
