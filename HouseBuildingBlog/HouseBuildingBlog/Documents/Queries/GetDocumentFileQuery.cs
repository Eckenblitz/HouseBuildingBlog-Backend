using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentFileQuery : IRequest<DocumentFileQueryDto>
	{
		public Guid DocumentId { get; }

		public GetDocumentFileQuery(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
