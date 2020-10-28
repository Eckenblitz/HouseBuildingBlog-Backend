using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class GetDocumentByEventIdQuery : IRequest<IActionResult>
	{
		public Guid EventId { get; }
		public GetDocumentByEventIdQuery(Guid eventId)
		{
			EventId = eventId;
		}
	}
}
