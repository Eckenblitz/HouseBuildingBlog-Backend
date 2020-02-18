using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Commands
{
	public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, IActionResult>
	{
		private readonly IDocumentRepository _repo;

		public UpdateDocumentHandler(IDocumentRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
		{
			var document = await _repo.Get(request.DocumentId);

			if (document != null)
			{
				document.UpdateTitle(request.Data.Title);
				document.UpdateComment(request.Data.Comment);

				return new OkResult();
			}

			return new NotFoundResult();
		}
	}
}
