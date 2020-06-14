using HouseBuildingBlog.Api.Tags.Queries.Contracts;
using HouseBuildingBlog.Domain.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Tags.Queries
{
	public class GetTagsHandler : IRequestHandler<GetTagsQuery, IActionResult>
	{
		private readonly IReadTagsAggregate _readTagsAggregate;

		public GetTagsHandler(IReadTagsAggregate readTagsAggregate)
		{
			_readTagsAggregate = readTagsAggregate;
		}

		public async Task<IActionResult> Handle(GetTagsQuery request, CancellationToken cancellationToken)
		{
			var tags = await _readTagsAggregate.GetAllAsync();
			return new OkObjectResult(tags.Select(t => new TagQueryDto(t)));
		}
	}
}
