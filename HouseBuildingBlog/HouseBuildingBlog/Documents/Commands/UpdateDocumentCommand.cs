using HouseBuildingBlog.Documents.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Documents.Commands
{
	public class UpdateDocumentCommand : IRequest<IActionResult>
	{
		public Guid Id { get; }

		public DocumentCommandDto Data { get; }

		public UpdateDocumentCommand(Guid id, DocumentCommandDto data)
		{
			this.Id = id;
			this.Data = data;
		}
	}
}
