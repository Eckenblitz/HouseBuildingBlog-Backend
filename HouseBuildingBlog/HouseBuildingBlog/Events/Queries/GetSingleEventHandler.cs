using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetSingleEventHandler : IRequestHandler<GetSingleEventQuery, EventQueryDto>
	{
		public Task<EventQueryDto> Handle(GetSingleEventQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
