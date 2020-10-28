using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class DownloadFileHandler : IRequestHandler<DownloadFileQuery, IActionResult>
	{
		public Task<IActionResult> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
		{
			//Domain
			throw new NotImplementedException();
		}
	}
}
