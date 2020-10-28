using HouseBuildingBlog.Api.Events.Models;
using HouseBuildingBlog.Api.Events.Queries.Contracts;
using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Events.Commands
{
	public class CreateEventHandler : IRequestHandler<CreateEventCommand, IActionResult>
	{
		private readonly IWriteEventsAggregate _writeEventsAggregate;

		public CreateEventHandler(IWriteEventsAggregate writeEventsAggregate)
		{
			_writeEventsAggregate = writeEventsAggregate;
		}

		public async Task<IActionResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var createdEvent = await _writeEventsAggregate.CreateEventAsync(new Event(request));
				return new CreatedResult(string.Empty, new EventQueryDto(createdEvent));
			}
			catch (ValidationException)
			{
				return new BadRequestResult();
			}

		}
	}
}
