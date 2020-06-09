using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Tags.Models;
using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
			var createdTag = await _writeTagsAggregate.CreateTagAsync(new Tag(request));

			return new CreatedResult(string.Empty, new TagQueryDto(createdTag));
		}
	}
}
