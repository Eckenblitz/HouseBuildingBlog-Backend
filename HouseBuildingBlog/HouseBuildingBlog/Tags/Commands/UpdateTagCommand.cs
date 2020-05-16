using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Tags.Commands
{
	public class UpdateTagCommand : IRequest<IActionResult>
	{
		public Guid TagId { get; }

		public string Title { get; }

		public UpdateTagCommand(Guid tagId, string title)
		{
			TagId = tagId;
			Title = title;
		}
	}
}
