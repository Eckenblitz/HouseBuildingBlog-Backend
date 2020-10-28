using HouseBuildingBlog.Api.Documents.Models;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand, IActionResult>
	{
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;

		public UpdateDocumentHandler(IWriteDocumentsAggregate writeDocumentsAggregate)
		{
			_writeDocumentsAggregate = writeDocumentsAggregate;
		}

		public async Task<IActionResult> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var updateDocument = await _writeDocumentsAggregate.UpdateDocumentAsync(new Document(request));
				if (updateDocument == null)
					return new NotFoundResult();
				return new OkObjectResult(new DocumentQueryDto(updateDocument));

			}
			catch
			{
				return new BadRequestResult();
			}

		}
	}
}
