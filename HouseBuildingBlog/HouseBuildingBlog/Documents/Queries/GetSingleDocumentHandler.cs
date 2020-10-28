using HouseBuildingBlog.Domain.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class GetSingleDocumentHandler : IRequestHandler<GetSingleDocumentQuery, IActionResult>
	{
		private readonly IReadDocumentsAggregate _readDocumentsAggregate;

		public GetSingleDocumentHandler(IReadDocumentsAggregate readDocumentsAggregate)
		{
			_readDocumentsAggregate = readDocumentsAggregate;
		}
		public async Task<IActionResult> Handle(GetSingleDocumentQuery request, CancellationToken cancellationToken)
		{
			var document = await _readDocumentsAggregate.GetAsync(request.DocumentId);
			return new OkObjectResult(document);

		}
	}
}
