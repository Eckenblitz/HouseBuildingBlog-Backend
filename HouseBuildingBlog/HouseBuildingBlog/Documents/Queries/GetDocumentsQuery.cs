using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System.Collections.Generic;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentsQuery : IRequest<IList<DocumentDto>>
	{
		public QueryDocumentsDto Query { get; }

		public GetDocumentsQuery(QueryDocumentsDto query)
		{
			Query = query;
		}
	}
}
