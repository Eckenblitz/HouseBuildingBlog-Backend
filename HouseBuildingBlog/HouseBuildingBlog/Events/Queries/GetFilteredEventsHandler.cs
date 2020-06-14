using HouseBuildingBlog.Api.Events.Queries.Contracts;
using HouseBuildingBlog.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Events.Queries
{
	public class GetFilteredEventsHandler : IRequestHandler<GetFilteredEventsQuery, IActionResult>
	{
		public readonly IReadEventsAggregate _readEventsAggregate;

		public GetFilteredEventsHandler(IReadEventsAggregate readEventsAggregate)
		{
			_readEventsAggregate = readEventsAggregate;
		}

		public async Task<IActionResult> Handle(GetFilteredEventsQuery request, CancellationToken cancellationToken)
		{
			var events = await _readEventsAggregate.FilterByTags(request.TagIds);
			return new OkObjectResult(events.Select(e => new SimpleEventQueryDto(e)));
		}
	}
}
