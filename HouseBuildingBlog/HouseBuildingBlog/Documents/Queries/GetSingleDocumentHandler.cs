using HouseBuildingBlog.Documents.Queries.Contracts;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetSingleDocumentHandler : IRequestHandler<GetSingleDocumentQuery, IActionResult>
	{
		private readonly IDocumentRepository _repo;

		public GetSingleDocumentHandler(IDocumentRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(GetSingleDocumentQuery request, CancellationToken cancellationToken)
		{
			var result = await _repo.Get(request.DocumentId);

			if (result != null)
				return new OkObjectResult(DocumentQueryDto.From(result));

			return new NotFoundResult();
		}
	}
}
