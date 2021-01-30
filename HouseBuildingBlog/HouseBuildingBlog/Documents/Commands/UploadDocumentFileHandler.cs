using HouseBuildingBlog.Api.Services;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class UploadDocumentFileHandler : IRequestHandler<UploadDocumentFileCommand, IActionResult>
	{
		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;
		private readonly ITransformFileService _transformFileService;

		public UploadDocumentFileHandler(IWriteDocumentsAggregate writeDocumentsAggregate, ITransformFileService transformFileService)
		{
			_writeDocumentsAggregate = writeDocumentsAggregate;
			_transformFileService = transformFileService;
		}

		public async Task<IActionResult> Handle(UploadDocumentFileCommand request, CancellationToken cancellationToken)
		{
			var file = await _transformFileService.TransformAsync(request.File);
			//ToDo: validate file? https://stackoverflow.com/questions/56588900/how-to-validate-uploaded-file-in-asp-net-core/56592790
			try
			{
				_ = await _writeDocumentsAggregate.UploadFileAsync(request.DocumentId, new DocumentFile(request.DocumentId, file));
			}
			catch (AggregateNotFoundException ex)
			{
				return new NotFoundObjectResult(ex.Error);
			}
			catch (ValidationException ex)
			{
				return new BadRequestObjectResult(ex.ValidationErrors);
			}

			//ToDO send with Data?
			return new OkResult();
		}
	}
}
