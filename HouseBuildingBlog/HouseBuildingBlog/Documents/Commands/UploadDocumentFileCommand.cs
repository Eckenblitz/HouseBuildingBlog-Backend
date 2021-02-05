using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class UploadDocumentFileCommand : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }

		public IFormFile File { get; }

		public UploadDocumentFileCommand(Guid documentId, IFormFile file)
		{
			DocumentId = documentId;
			File = file;
		}
	}
}
