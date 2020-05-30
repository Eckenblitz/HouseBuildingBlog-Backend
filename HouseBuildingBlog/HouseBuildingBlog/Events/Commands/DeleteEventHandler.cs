﻿using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, IActionResult>
	{
		private readonly IWriteRepository<IEvent> _writeRepo;
		private readonly IReadRepository<IEvent> _readRepo;

		public DeleteEventHandler(IWriteRepository<IEvent> writeRepo, IReadRepository<IEvent> readRepo)
		{
			_writeRepo = writeRepo;
			_readRepo = readRepo;
		}

		public async Task<IActionResult> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
		{
			var @event = await _readRepo.GetById(request.EventId);

			if (@event == null)
				return new NotFoundResult();

			await _writeRepo.Delete(@event.EventId);

			return new OkResult();
		}
	}
}
