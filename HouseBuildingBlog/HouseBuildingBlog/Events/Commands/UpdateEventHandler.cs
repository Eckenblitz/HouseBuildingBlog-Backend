using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, IActionResult>
	{
		private readonly IWriteRepository<IEvent> _writeRepo;
		private readonly IReadRepository<IEvent> _readRepo;
		private readonly IReadRepository<ITag> _tagReadRepo;

		public UpdateEventHandler(IWriteRepository<IEvent> writeRepo, IReadRepository<IEvent> readRepo, IReadRepository<ITag> tagReadRepo)
		{
			_writeRepo = writeRepo;
			_readRepo = readRepo;
			_tagReadRepo = tagReadRepo;
		}

		public async Task<IActionResult> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
		{
			var @event = await _readRepo.GetById(request.EventId);
			if (@event == null)
				return new NotFoundResult();

			var toUpdate = new Event(@event);

			toUpdate.UpdateTitle(request.Data.Title);
			toUpdate.UpdateDate(request.Data.Date);
			toUpdate.UpdateDescription(request.Data.Description);

			if (request.Data.TagIds != null)
			{
				var tags = await _tagReadRepo.Query(tag => request.Data.TagIds.Contains(tag.TagId));
				toUpdate.UpdateTags(tags);
			}
			else
				toUpdate.UpdateTags(new List<ITag>());

			await _writeRepo.Save(toUpdate);

			return new OkResult();
		}
	}
}
