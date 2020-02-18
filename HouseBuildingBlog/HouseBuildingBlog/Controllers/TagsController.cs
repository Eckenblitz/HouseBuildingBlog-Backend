using HouseBuildingBlog.Tags.Commands;
using HouseBuildingBlog.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagsController : ControllerBase
	{
		private readonly ILogger<TagsController> _logger;
		private readonly IMediator _mediator;

		public TagsController(ILogger<TagsController> logger, IMediator mediator)
		{
			_logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
			_mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
		}

		[HttpPost]
		public async Task<IActionResult> CreateTag([FromBody] Tags.Commands.Contracts.TagCommandDto dto)
		{
			return await _mediator.Send(new CreateTagCommand(dto));
		}

		[HttpGet]
		public async Task<IActionResult> GetTags()
		{
			return await _mediator.Send(new GetTagsQuery());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSingleTag(Guid id)
		{
			return await _mediator.Send(new GetSingleTagQuery(id));
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateTag(Guid id, [FromBody] Tags.Commands.Contracts.TagCommandDto dto)
		{
			return await _mediator.Send(new UpdateTagCommand(id, dto));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTag(Guid id)
		{
			return await _mediator.Send(new DeleteTagCommand(id));
		}
	}
}