using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class CreateEventHandler : IRequestHandler<CreateEventCommand, IActionResult>
	{
		private readonly IWriteRepository<IEvent> _writeRepo;
		private readonly IReadRepository<ITag> _tagReadRepo;

		public CreateEventHandler(IWriteRepository<IEvent> writeRepo, IReadRepository<ITag> tagReadRepo)
		{
			_writeRepo = writeRepo;
			_tagReadRepo = tagReadRepo;
		}

		public async Task<IActionResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			var @event = new Event(Guid.NewGuid(), request.Data.Title, request.Data.Date);
			@event.UpdateDescription(request.Data.Description);

			if (request.Data.TagIds != null)
			{
				var tags = await _tagReadRepo.Query(tag => request.Data.TagIds.Contains(tag.TagId));
				@event.UpdateTags(tags);
			}

			await _writeRepo.Save(@event);

			return new CreatedResult(string.Empty, new { @event.EventId });
		}
	}
}
