using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetSingleEventHandler : IRequestHandler<GetSingleEventQuery, IActionResult>
	{
		private readonly IReadEventsAggregate _readEventsAggregate;

		public GetSingleEventHandler(IReadEventsAggregate readEventsAggregate)
		{
			_readEventsAggregate = readEventsAggregate;
		}

		public async Task<IActionResult> Handle(GetSingleEventQuery request, CancellationToken cancellationToken)
		{
			var @event = await _readEventsAggregate.GetAsync(request.EventId);

			if (@event == null)
				return new NotFoundResult();

			return new OkObjectResult(EventQueryDto.CreateFrom(@event));
		}
	}
}
