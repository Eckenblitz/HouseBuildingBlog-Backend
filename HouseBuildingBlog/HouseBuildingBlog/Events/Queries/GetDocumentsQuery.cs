using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using System.Collections.Generic;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetDocumentsQuery : IRequest<IList<EventDto>>
	{
		public QueryEventsDto Query { get; }

		public GetDocumentsQuery(QueryEventsDto query)
		{
			Query = query;
		}
	}
}
