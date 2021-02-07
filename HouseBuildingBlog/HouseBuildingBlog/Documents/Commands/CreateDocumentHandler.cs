using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, IActionResult>
	{
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public CreateDocumentHandler(IWriteDocumentsAggregate writeDocumentsAggregate)
		{
			_writeDocumentsAggregate = writeDocumentsAggregate;
		}

		public async Task<IActionResult> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var newDocument = await _writeDocumentsAggregate.CreateDocumentAsync(request, request.TagIds);
				return new CreatedResult(string.Empty, new DocumentQueryDto(newDocument));
			}
			catch (ValidationException ex)
			{
				return new BadRequestObjectResult(ex.ValidationErrors);
			}
		}
	}


}
