using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetDocumentsHandler : IRequestHandler<GetDocumentsQuery, IList<EventDto>>
	{
		public Task<IList<EventDto>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
