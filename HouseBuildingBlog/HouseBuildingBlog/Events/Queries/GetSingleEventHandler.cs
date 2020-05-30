using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Events.Queries.Contracts;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetSingleEventHandler : IRequestHandler<GetSingleEventQuery, IActionResult>
	{
		private readonly IReadRepository<IEvent> _readRepo;

		public GetSingleEventHandler(IReadRepository<IEvent> readRepo)
		{
			_readRepo = readRepo;
		}

		public async Task<IActionResult> Handle(GetSingleEventQuery request, CancellationToken cancellationToken)
		{
			var @event = await _readRepo.GetById(request.EventId);

			if (@event == null)
				return new NotFoundResult();

			return new OkObjectResult(EventQueryDto.CreateFrom(@event));
		}
	}
}
