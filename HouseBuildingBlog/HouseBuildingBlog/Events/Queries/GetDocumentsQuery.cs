using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetDocumentsQuery : IRequest<IList<SimpleEventQueryDto>>
	{
		public IList<Guid> TagIds { get; }

		public GetDocumentsQuery(IList<Guid> tagIds)
		{
			TagIds = new List<Guid>(tagIds);
		}
	}
}
