using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class UnassignEventFromDocumentCommand : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }

		public UnassignEventFromDocumentCommand(Guid documentId)
		{
			DocumentId = documentId;
		}
	}
}
