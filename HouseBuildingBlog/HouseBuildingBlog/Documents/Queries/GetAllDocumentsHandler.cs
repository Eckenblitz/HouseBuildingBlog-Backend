using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class GetAllDocumentsHandler : IRequestHandler<GetAllDocumentsQuery, IActionResult>
	{
		private readonly IReadDocumentsAggregate _readDocumentsAggegate;

		public GetAllDocumentsHandler(IReadDocumentsAggregate readDocumentsAggegate)
		{
			_readDocumentsAggegate = readDocumentsAggegate;
		}

		public async Task<IActionResult> Handle(GetAllDocumentsQuery request, CancellationToken cancellationToken)
		{
			var documents = await _readDocumentsAggegate.GetAllAsync();
			return new OkObjectResult(documents.Select(d => new DocumentQueryDto(d)).ToList());
		}
	}
}
