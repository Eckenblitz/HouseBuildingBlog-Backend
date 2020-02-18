using HouseBuildingBlog.Persistence;
using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Queries
{
	public class GetSingleTagHandler : IRequestHandler<GetSingleTagQuery, IActionResult>
	{
		private readonly ITagRepository _repo;

		public GetSingleTagHandler(ITagRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(GetSingleTagQuery request, CancellationToken cancellationToken)
		{
			var tag = await _repo.Get(request.TagId);
			if (tag != null)
				return new OkObjectResult(TagQueryDto.From(tag));

			return new NotFoundResult();
		}
	}
}
