using HouseBuildingBlog.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TagsController(IMediator mediator)
		{
			_mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
		}

		[HttpGet]
		public async Task<IActionResult> GetTags()
		{
			return await _mediator.Send(new GetTagsQuery());
		}
	}
}