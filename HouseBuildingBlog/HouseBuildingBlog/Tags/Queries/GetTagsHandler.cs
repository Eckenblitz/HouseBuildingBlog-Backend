using HouseBuildingBlog.Persistence;
using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Queries
{
	public class GetTagsHandler : IRequestHandler<GetTagsQuery, IActionResult>
	{
		private readonly ITagRepository _repo;

		public GetTagsHandler(ITagRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(GetTagsQuery request, CancellationToken cancellationToken)
		{
			var result = await _repo.Query(t => true);
			return new OkObjectResult(result.Select(t => new TagQueryDto() { TagId = t.TagId, Title = t.Title }));
		}
	}
}
