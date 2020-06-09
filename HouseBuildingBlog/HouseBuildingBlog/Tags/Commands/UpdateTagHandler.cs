﻿using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Tags.Models;
using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
	public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, IActionResult>
	{
		private readonly IWriteTagsAggregate _writeTagsAggregate;

		public UpdateTagHandler(IWriteTagsAggregate writeTagsAggregate)
		{
			_writeTagsAggregate = writeTagsAggregate;
		}

		public async Task<IActionResult> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
		{
			var updatedTag = await _writeTagsAggregate.UpdateTagAsync(new Tag(request));

			if (updatedTag == null)
				return new NotFoundResult();

			return new OkObjectResult(new TagQueryDto(updatedTag));
		}
	}
}
