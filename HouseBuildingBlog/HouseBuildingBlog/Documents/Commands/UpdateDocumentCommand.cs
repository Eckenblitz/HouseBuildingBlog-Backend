using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class UpdateDocumentCommand : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }
		public DocumentCommandDto Data { get; }

		public UpdateDocumentCommand(Guid id, DocumentCommandDto data)
		{
			DocumentId = id;
			Data = data;
		}
	}
}
