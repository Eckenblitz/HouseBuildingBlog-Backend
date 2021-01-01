using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Events.Queries
{
	public class GetDocumentsQuery : IRequest<IActionResult>
	{
		public Guid EventId { get; }

		public GetDocumentsQuery(Guid eventId)
		{
			EventId = eventId;
		}
	}
}
