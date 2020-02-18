using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentFileQuery : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }

		public GetDocumentFileQuery(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
