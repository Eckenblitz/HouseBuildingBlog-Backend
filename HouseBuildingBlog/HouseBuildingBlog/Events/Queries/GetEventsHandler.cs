using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetEventsHandler : IRequestHandler<GetEventsQuery, IActionResult>
	{
		public Task<IActionResult> Handle(GetEventsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
