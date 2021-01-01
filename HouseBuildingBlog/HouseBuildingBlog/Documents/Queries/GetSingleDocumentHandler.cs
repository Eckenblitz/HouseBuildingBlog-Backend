using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
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
			try
			{
				var document = await _readDocumentsAggregate.GetByIdAsync(request.DocumentId);
				return new OkObjectResult(new DocumentQueryDto(document));
			}
			catch (AggregateNotFoundException ex)
			{
				return new NotFoundObjectResult(ex.Error);
			}
		}
	}
}
