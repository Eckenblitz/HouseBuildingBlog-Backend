using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Documents.Commands
{
	public class DeleteDocumentCommand : IRequest<IActionResult>
	{
		public Guid Id { get; }

		public DeleteDocumentCommand(Guid id)
		{
			Id = id;
		}
	}
}
