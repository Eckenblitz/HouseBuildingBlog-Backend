using HouseBuildingBlog.Documents.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Documents.Commands
{
	public class UpdateDocumentCommand : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }

		public DocumentCommandDto Data { get; }

		public UpdateDocumentCommand(Guid documentId, DocumentCommandDto data)
		{
			this.DocumentId = documentId;
			this.Data = data;
		}
	}
}
