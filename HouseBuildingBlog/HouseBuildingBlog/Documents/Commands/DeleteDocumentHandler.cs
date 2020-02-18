using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Commands
{
	public class DeleteDocumentHandler : IRequestHandler<DeleteDocumentCommand, IActionResult>
	{
		private readonly IDocumentRepository _repo;

		public DeleteDocumentHandler(IDocumentRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
		{
			await _repo.Delete(request.DocumentId);
			return new OkResult();
		}
	}
}
