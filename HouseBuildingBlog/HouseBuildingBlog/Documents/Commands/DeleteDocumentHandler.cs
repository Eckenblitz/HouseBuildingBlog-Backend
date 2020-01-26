using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Commands
{
	public class DeleteDocumentHandler : IRequestHandler<DeleteDocumentCommand, IActionResult>
	{
		public Task<IActionResult> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
