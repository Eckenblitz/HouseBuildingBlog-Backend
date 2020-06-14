using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Api.Tags.Commands
{
	public class CreateTagCommand : IRequest<IActionResult>
	{
		public string Title { get; }

		public CreateTagCommand(string title)
		{
			Title = title;
		}
	}
}
