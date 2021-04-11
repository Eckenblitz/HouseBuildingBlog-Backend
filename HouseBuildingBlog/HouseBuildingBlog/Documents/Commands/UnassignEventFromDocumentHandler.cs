using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class UnassignEventFromDocumentHandler : IRequestHandler<UnassignEventFromDocumentCommand, IActionResult>
	{
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public UnassignEventFromDocumentHandler(IWriteDocumentsAggregate writeDocumentsAggregate)
		{
			_writeDocumentsAggregate = writeDocumentsAggregate;
		}

		public async Task<IActionResult> Handle(UnassignEventFromDocumentCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var document = await _writeDocumentsAggregate.UnassignEventAsync(request.DocumentId);
				return new OkObjectResult(new DocumentQueryDto(document));
			}
			catch (AggregateNotFoundException ex)
			{
				return new NotFoundObjectResult(ex.Error);
			}
			catch (ValidationException ex)
			{
				return new BadRequestObjectResult(ex.ValidationErrors);
			}
		}
	}
}
