using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class DownloadFileQuery : IRequest<IActionResult>
	{

		public Guid DocumentId { get; }

		public DownloadFileQuery(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
