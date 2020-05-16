using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetSingleEventQuery : IRequest<IActionResult>
	{
		public Guid EventId { get; }

		public GetSingleEventQuery(Guid eventId)
		{
			EventId = eventId;
		}
	}
}
