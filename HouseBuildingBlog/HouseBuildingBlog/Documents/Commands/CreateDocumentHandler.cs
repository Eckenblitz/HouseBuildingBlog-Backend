using HouseBuildingBlog.Api.Documents.Models;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Validation;
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
				var newDocument = await _writeDocumentsAggregate.CreateDocumentAsync(new Document(request));
				return new CreatedResult(string.Empty, newDocument);
			}
			catch (ValidationException)
			{

				return new BadRequestResult();
			}
		}
	}


}
