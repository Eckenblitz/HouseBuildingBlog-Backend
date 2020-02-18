using HouseBuildingBlog.Documents.Queries.Contracts;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentsHandler : IRequestHandler<GetDocumentsQuery, IActionResult>
	{
		private readonly IDocumentRepository _repo;

		public GetDocumentsHandler(IDocumentRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
		{
			var queryResult = await _repo.Query(d => true);
			IList<DocumentQueryDto> result = new List<DocumentQueryDto>(queryResult.Select(d => DocumentQueryDto.From(d)));

			return new OkObjectResult(result);
		}
	}
}
