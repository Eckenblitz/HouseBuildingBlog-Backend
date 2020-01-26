using HouseBuildingBlog.Events.Queries.Contracts;
using MediatR;
using System;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetSingleEventQuery : IRequest<EventDto>
	{
		public Guid EventId { get; }

		public GetSingleEventQuery(Guid eventId)
		{
			EventId = eventId;
		}
	}
}
