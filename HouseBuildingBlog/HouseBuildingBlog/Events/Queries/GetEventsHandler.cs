using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetEventsHandler : IRequestHandler<GetEventsQuery, IActionResult>
	{
		public readonly IReadEventsAggregate _readEventsAggregate;

		public GetEventsHandler(IReadEventsAggregate readEventsAggregate)
		{
			_readEventsAggregate = readEventsAggregate;
		}

		public async Task<IActionResult> Handle(GetEventsQuery request, CancellationToken cancellationToken)
		{
			var events = await _readEventsAggregate.GetEventsByTagsAsync(request.TagIds);
			return new OkObjectResult(events.Select(e => SimpleEventQueryDto.CreateFrom(e)));
		}
	}
}
