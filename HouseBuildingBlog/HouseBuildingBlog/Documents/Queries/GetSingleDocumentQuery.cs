using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class GetSingleDocumentQuery : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }

		public GetSingleDocumentQuery(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
