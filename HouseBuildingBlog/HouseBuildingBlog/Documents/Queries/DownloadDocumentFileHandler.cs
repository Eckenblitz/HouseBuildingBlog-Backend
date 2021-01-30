using HouseBuildingBlog.Api.Services;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using MediatR;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class DownloadDocumentFileHandler : IRequestHandler<DownloadDocumentFileQuery, HttpResponseMessage>
	{
		private readonly IReadDocumentsAggregate _readDocumentsAggregate;
		private readonly IFileResponseService _fileResponseService;

		public async Task<HttpResponseMessage> Handle(DownloadDocumentFileQuery request, CancellationToken cancellationToken)
		{
			IDocumentFile file;
			try
			{
				file = await _readDocumentsAggregate.DownloadFile(request.DocumentId);
			}
			catch (AggregateNotFoundException)
			{
				//ToDo: integrate exception into result?
				return new HttpResponseMessage(HttpStatusCode.NotFound);
			}

			return _fileResponseService.CreateFileResponse(file);
		}
	}
}
