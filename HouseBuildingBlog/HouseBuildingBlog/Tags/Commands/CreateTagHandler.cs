using HouseBuildingBlog.Api.Tags.Models;
using HouseBuildingBlog.Api.Tags.Queries.Contracts;
using HouseBuildingBlog.Domain.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Tags.Commands
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
			var createdTag = await _writeTagsAggregate.CreateTagAsync(new Tag(request));

			return new CreatedResult(string.Empty, new TagQueryDto(createdTag));
		}
	}
}
