using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class GetFilteredDocumentsHandler : IRequestHandler<GetFilteredDocumentsQuery, IActionResult>
	{
		private readonly IReadDocumentsAggregate _readDocumentsAggregate;

		public GetFilteredDocumentsHandler(IReadDocumentsAggregate readDocumentsAggregate)
		{
			_readDocumentsAggregate = readDocumentsAggregate;
		}

		public async Task<IActionResult> Handle(GetFilteredDocumentsQuery request, CancellationToken cancellationToken)
		{
			var documents = await _readDocumentsAggregate.FilterByTagsAsync(request.TagIds);
			return new OkObjectResult(documents.Select(d => new DocumentQueryDto(d)));
		}
	}
}
