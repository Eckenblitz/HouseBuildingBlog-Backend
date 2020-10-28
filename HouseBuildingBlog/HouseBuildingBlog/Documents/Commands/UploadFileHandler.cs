using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class UploadFileHandler : IRequestHandler<UploadFileCommand, IActionResult>
	{
		public Task<IActionResult> Handle(UploadFileCommand request, CancellationToken cancellationToken)
		{
			//Domain
			throw new NotImplementedException();
		}
	}
}
