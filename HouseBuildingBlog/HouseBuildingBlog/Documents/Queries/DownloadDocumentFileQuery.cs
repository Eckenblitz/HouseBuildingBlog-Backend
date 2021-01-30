using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class DownloadDocumentFileQuery : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }

		public DownloadDocumentFileQuery(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
