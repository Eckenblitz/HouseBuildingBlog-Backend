using HouseBuildingBlog.Documents.Queries.Contracts;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentFileHandler : IRequestHandler<GetDocumentFileQuery, IActionResult>
	{
		private readonly IDocumentRepository _repo;

		public GetDocumentFileHandler(IDocumentRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(GetDocumentFileQuery request, CancellationToken cancellationToken)
		{
			var document = await _repo.Get(request.DocumentId);

			if (document != null)
				return new OkObjectResult(DocumentFileQueryDto.From(document));

			return new NotFoundResult();
		}
	}
}
