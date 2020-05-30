using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Events.Queries.Contracts;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetEventsHandler : IRequestHandler<GetEventsQuery, IActionResult>
	{
		public readonly IReadRepository<IEvent> _readRepo;

		public GetEventsHandler(IReadRepository<IEvent> readRepo)
		{
			_readRepo = readRepo;
		}

		public async Task<IActionResult> Handle(GetEventsQuery request, CancellationToken cancellationToken)
		{
			IList<IEvent> events = new List<IEvent>();

			if (request.TagIds.Count == 0)
				events = await _readRepo.Query(e => true);
			else
				events = await _readRepo.Query(e => e.Tags.Select(t => t.TagId).Intersect(request.TagIds).Count() > 0);


			return new OkObjectResult(events.Select(e => SimpleEventQueryDto.CreateFrom(e)));
		}
	}
}
