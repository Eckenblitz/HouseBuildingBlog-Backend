using HouseBuildingBlog.Api.Documents.Queries;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class DeleteDocumentHandler : IRequestHandler<DeleteDocumentCommand, IActionResult>
	{
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public DeleteDocumentHandler(IWriteDocumentsAggregate writeDocumentsAggregate)
		{
			_writeDocumentsAggregate = writeDocumentsAggregate;
		}

		public async Task<IActionResult> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var deleteDocument = await _writeDocumentsAggregate.DeleteDocumentAsync(request.DocumentId);
				return new OkObjectResult(new DocumentQueryDto(deleteDocument));
			}
			catch (AggregateNotFoundException ex)
			{
				return new NotFoundObjectResult(ex.Error);
			}
			catch
			{
				return new BadRequestResult();
			}
		}
	}
}
