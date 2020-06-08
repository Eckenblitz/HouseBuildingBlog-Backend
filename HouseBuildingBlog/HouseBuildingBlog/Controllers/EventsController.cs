using HouseBuildingBlog.Events.Commands;
using HouseBuildingBlog.Events.Queries;
using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EventsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EventsController(IMediator mediator)
		{
			_mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
		}

		[HttpPost]
		[ProducesResponseType(typeof(EventQueryDto), StatusCodes.Status201Created)]
		public async Task<IActionResult> CreateEvent([FromBody] Events.Commands.Contracts.EventCommandDto dto)
		{
			return await _mediator.Send(new CreateEventCommand(dto));
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(EventQueryDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetSingleEvent(Guid id)
		{
			return await _mediator.Send(new GetSingleEventQuery(id));
		}

		[HttpGet]
		[ProducesResponseType(typeof(IList<SimpleEventQueryDto>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetEvents([FromQuery]IList<Guid> tagIds)
		{
			if (tagIds.Count > 0)
				return await _mediator.Send(new GetFilteredEventsQuery(tagIds));
			else
				return await _mediator.Send(new GetAllEventsQuery());
		}

		[HttpPatch("{id}")]
		[ProducesResponseType(typeof(EventQueryDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateEvent(Guid id, [FromBody]Events.Commands.Contracts.EventCommandDto dto)
		{
			return await _mediator.Send(new UpdateEventCommand(id, dto));
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(EventQueryDto), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteEvent(Guid id)
		{
			return await _mediator.Send(new DeleteEventCommand(id));
		}
	}
}
