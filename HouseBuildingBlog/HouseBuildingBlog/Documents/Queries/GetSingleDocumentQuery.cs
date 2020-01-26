using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetSingleDocumentQuery : IRequest<DocumentDto>
	{
		public Guid DocumentId { get; }

		public GetSingleDocumentQuery(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
