using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentsHandler : IRequestHandler<GetDocumentsQuery, IList<DocumentQueryDto>>
	{
		public Task<IList<DocumentQueryDto>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
