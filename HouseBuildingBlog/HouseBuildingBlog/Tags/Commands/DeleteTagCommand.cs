﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Tags.Commands
{
	public class DeleteTagCommand : IRequest<IActionResult>
	{
		public Guid TagId { get; }

		public DeleteTagCommand(Guid tagId)
		{
			TagId = tagId;
		}
	}
}
