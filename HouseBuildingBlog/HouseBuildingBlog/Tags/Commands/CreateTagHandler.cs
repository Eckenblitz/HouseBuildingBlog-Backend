using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
	public class CreateTagHandler : IRequestHandler<CreateTagCommand, IActionResult>
	{
		private readonly IWriteTagsAggregate _writeTagsAggregate;

		public CreateTagHandler(IWriteTagsAggregate writeTagsAggregate)
		{
			_writeTagsAggregate = writeTagsAggregate;
		}

		public async Task<IActionResult> Handle(CreateTagCommand request, CancellationToken cancellationToken)
		{
			var tag = new Tag(Guid.NewGuid(), request.Title);

			var createdTag = await _writeTagsAggregate.CreateTagAsync(tag);

			return new CreatedResult(string.Empty, new TagQueryDto(createdTag));
		}
	}
}
