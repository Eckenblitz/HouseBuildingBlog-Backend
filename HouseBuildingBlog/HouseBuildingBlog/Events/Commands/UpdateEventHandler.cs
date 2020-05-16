using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, IActionResult>
	{
		private readonly IWriteRepository<Event> _writeRepo;
		private readonly IReadRepository<Event> _readRepo;

		public UpdateEventHandler(IWriteRepository<Event> writeRepo, IReadRepository<Event> readRepo)
		{
			_writeRepo = writeRepo;
			_readRepo = readRepo;
		}

		public async Task<IActionResult> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
		{
			var @event = await _readRepo.GetById(request.EventId);

			if (@event == null)
				return new NotFoundResult();

			@event.UpdateTitle(request.Data.Title);
			@event.UpdateDate(request.Data.Date);
			@event.UpdateDescription(request.Data.Description);
			if (request.Data.TagIds != null)
				@event.UpdateTags(request.Data.TagIds);

			await _writeRepo.Save(@event);

			return new OkResult();
		}
	}
}
