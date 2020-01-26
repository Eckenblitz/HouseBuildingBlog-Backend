using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentsHandler : IRequestHandler<GetDocumentsQuery, IList<DocumentDto>>
	{
		public Task<IList<DocumentDto>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
