using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, IActionResult>
    {
        private readonly IWriteRepository<Event> _eventRepo;
        private readonly ILogger<CreateEventHandler> _logger;

        public CreateEventHandler(IWriteRepository<Event> eventRepo, ILogger<CreateEventHandler> logger)
        {
            _eventRepo = eventRepo;
            _logger = logger;
        }

        public async Task<IActionResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = new Event(Guid.NewGuid(), request.Data.Title, request.Data.Date);
            //foreach(var content in request.Data.ContentSection)
            await _eventRepo.Save(@event);
            throw new NotImplementedException();
        }
    }
}
