using HouseBuildingBlog.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
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
			return new OkObjectResult(await _readEventsAggregate.GetAllAsync());
		}
	}
}
