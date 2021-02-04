using HouseBuildingBlog.Api.Services;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Persistence.MSSql.Files;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class DownloadDocumentFileHandler : IRequestHandler<DownloadDocumentFileQuery, IActionResult>
	{
		private readonly IReadDocumentsAggregate _readDocumentsAggregate;
		private readonly IFileResponseService _fileResponseService;

		public DownloadDocumentFileHandler(IReadDocumentsAggregate readDocumentsAggregate, IFileResponseService fileResponseService)
		{
			_readDocumentsAggregate = readDocumentsAggregate;
			_fileResponseService = fileResponseService;
		}

		public async Task<IActionResult> Handle(DownloadDocumentFileQuery request, CancellationToken cancellationToken)
		{
			IDocumentFile file;
			try
			{
				file = await _readDocumentsAggregate.DownloadFileAsync(request.DocumentId);
			}
			catch (Exception ex) when (ex is AggregateNotFoundException || ex is FileNotFoundException<IDocumentFile>)
			{
				return new NotFoundObjectResult(ex);
			}

			return _fileResponseService.CreateFileContentResult(file);
		}
	}
}
