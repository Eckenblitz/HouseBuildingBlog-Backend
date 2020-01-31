using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System.Collections.Generic;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentsQuery : IRequest<IList<DocumentQueryDto>>
	{
	}
}
