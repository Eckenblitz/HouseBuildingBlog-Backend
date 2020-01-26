using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Commands
{
	public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, IActionResult>
	{
		public Task<IActionResult> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}
