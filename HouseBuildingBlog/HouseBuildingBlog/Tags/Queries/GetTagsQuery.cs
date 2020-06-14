using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Api.Tags.Queries
{
	public class GetTagsQuery : IRequest<IActionResult>
	{
	}
}
