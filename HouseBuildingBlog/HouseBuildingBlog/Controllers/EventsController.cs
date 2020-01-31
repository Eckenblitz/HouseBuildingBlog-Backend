using HouseBuildingBlog.Events.Commands;
using HouseBuildingBlog.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EventsController : ControllerBase
	{
		private readonly ILogger<EventsController> _logger;
		private readonly IMediator _mediator;

		public EventsController(ILogger<EventsController> logger, IMediator mediator)
		{
			_logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
			_mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
		}

		[HttpPost]
		public async Task<IActionResult> CreateEvent([FromBody] Events.Commands.Contracts.EventCommandDto dto)
		{
			return await _mediator.Send(new CreateEventCommand(dto));
		}

		[HttpGet("{id}")]
		public async Task<Events.Queries.Contracts.EventQueryDto> GetSingleEvent(Guid id)
		{
			return await _mediator.Send(new GetSingleEventQuery(id));
		}

		[HttpGet]
		public async Task<IList<Events.Queries.Contracts.SimpleEventQueryDto>> GetEvents(IList<Guid> tags)
		{
#warning List<Guid> Tags wont work
			return await _mediator.Send(new GetDocumentsQuery(tags));
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateEvent(Guid id, [FromBody]Events.Commands.Contracts.EventCommandDto dto)
		{
			return await _mediator.Send(new UpdateEventCommand(id, dto));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvent(Guid id)
		{
			return await _mediator.Send(new DeleteEventCommand(id));
		}
	}
}
