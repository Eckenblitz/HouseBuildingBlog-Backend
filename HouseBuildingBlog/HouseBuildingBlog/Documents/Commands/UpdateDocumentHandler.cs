using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Commands
{
	public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, IActionResult>
	{
		public Task<IActionResult> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
