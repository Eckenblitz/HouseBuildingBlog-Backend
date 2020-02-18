using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Tags.Queries
{
	public class GetTagsQuery : IRequest<IActionResult>
	{
	}
}
