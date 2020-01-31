using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetSingleDocumentHandler : IRequestHandler<GetSingleDocumentQuery, DocumentQueryDto>
	{
		public Task<DocumentQueryDto> Handle(GetSingleDocumentQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
