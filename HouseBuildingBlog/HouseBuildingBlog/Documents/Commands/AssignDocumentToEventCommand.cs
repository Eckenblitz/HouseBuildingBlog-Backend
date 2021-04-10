using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class AssignDocumentToEventCommand : IRequest<IActionResult>
	{
		public Guid DocumentId { get; }

		public Guid EventId { get; }

		public AssignDocumentToEventCommand(Guid documentId, Guid eventId)
		{
			DocumentId = documentId;
			EventId = eventId;
		}
	}
}
