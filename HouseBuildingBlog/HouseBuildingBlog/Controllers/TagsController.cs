using HouseBuildingBlog.Api.Tags.Commands;
using HouseBuildingBlog.Api.Tags.Commands.Contracts;
using HouseBuildingBlog.Api.Tags.Queries;
using HouseBuildingBlog.Api.Tags.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TagsController(IMediator mediator)
		{
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		[HttpPost]
		[ProducesResponseType(typeof(TagQueryDto), StatusCodes.Status201Created)]
		public async Task<IActionResult> CreateTag([FromBody] TagCommandDto data)
		{
			return await _mediator.Send(new CreateTagCommand(data.Title));
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<TagQueryDto>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetTags()
		{
			return await _mediator.Send(new GetTagsQuery());
		}

		[HttpPatch("{id}")]
		[ProducesResponseType(typeof(TagQueryDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateTag(Guid id, [FromBody] TagCommandDto data)
		{
			return await _mediator.Send(new UpdateTagCommand(id, data.Title));
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(TagQueryDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteTag(Guid id)
		{
			return await _mediator.Send(new DeleteTagCommand(id));
		}
	}
}