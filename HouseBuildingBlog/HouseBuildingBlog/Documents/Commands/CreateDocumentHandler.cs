using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Documents.Commands
{
	public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand, IActionResult>
	{
		private readonly IDocumentRepository _repo;

		public CreateDocumentHandler(IDocumentRepository repo)
		{
			_repo = repo;
		}

		public async Task<IActionResult> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
		{
			var document = new Document(Guid.NewGuid(), request.Data.Title);
			document.UpdateComment(request.Data.Comment);
			document.UpdateFile(request.Data.File.FileName, request.Data.File.BinaryData);

			await _repo.Save(document);

			return new OkResult();
		}
	}
}
