using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
	}
}
