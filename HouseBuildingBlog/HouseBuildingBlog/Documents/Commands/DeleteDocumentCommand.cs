using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class DeleteDocumentCommand : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }

		public DeleteDocumentCommand(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
