using MediatR;
using System;
using System.Net.Http;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class DownloadDocumentFileQuery : IRequest<HttpResponseMessage>
	{
		public Guid DocumentId { get; }

		public DownloadDocumentFileQuery(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
