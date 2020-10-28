using HouseBuildingBlog.Domain.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class GetDocumentByEventIdHandler : IRequestHandler<GetDocumentByEventIdQuery, IActionResult>
	{
		IReadDocumentsAggregate _readDocumentsAggreate;

		public GetDocumentByEventIdHandler(IReadDocumentsAggregate readDocumentsAggreate)
		{
			_readDocumentsAggreate = readDocumentsAggreate;
		}

		public async Task<IActionResult> Handle(GetDocumentByEventIdQuery request, CancellationToken cancellationToken)
		{
			var document = await _readDocumentsAggreate.GetByEventIdAsync(request.EventId);
			return new OkObjectResult(document);
		}
	}
}
