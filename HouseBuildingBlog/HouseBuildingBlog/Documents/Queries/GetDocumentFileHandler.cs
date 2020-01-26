using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentFileHandler : IRequestHandler<GetDocumentFileQuery, DocumentFileDto>
	{
		public Task<DocumentFileDto> Handle(GetDocumentFileQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
