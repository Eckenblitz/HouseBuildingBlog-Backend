using HouseBuildingBlog.Api.Events.Queries.Contracts;
using HouseBuildingBlog.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Events.Queries
{
	public class GetAllEventsHandler : IRequestHandler<GetAllEventsQuery, IActionResult>
	{
		private readonly IReadEventsAggregate _readEventsAggregate;

		public GetAllEventsHandler(IReadEventsAggregate readEventsAggregate)
		{
			_readEventsAggregate = readEventsAggregate;
		}

		public async Task<IActionResult> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
		{
			var events = await _readEventsAggregate.GetAllAsync();
			return new OkObjectResult(events.Select(e => new SimpleEventQueryDto(e)));
		}
	}
}
