using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class CreateEventHandler : IRequestHandler<CreateEventCommand, IActionResult>
	{
		private readonly IWriteRepository<Event> _writeRepo;

		public CreateEventHandler(IWriteRepository<Event> writeRepo)
		{
			_writeRepo = writeRepo;
		}

		public async Task<IActionResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			var @event = new Event(Guid.NewGuid(), request.Data.Title, request.Data.Date);
			@event.UpdateDescription(request.Data.Description);
			if (request.Data.TagIds != null)
				@event.UpdateTags(request.Data.TagIds);

			await _writeRepo.Save(@event);

			return new CreatedResult(string.Empty, new { @event.EventId });
		}
	}
}
