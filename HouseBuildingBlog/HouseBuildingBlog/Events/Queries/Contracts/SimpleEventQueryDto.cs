using HouseBuildingBlog.Domain.Events;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Events.Queries.Contracts
{
	public class SimpleEventQueryDto
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public IEnumerable<Guid> DocumentIds { get; set; }

		public SimpleEventQueryDto(IEvent @event)
		{
			EventId = @event.EventId;
			Date = @event.Date;
			Title = @event.Title;
			Description = @event.Description;
			DocumentIds = @event?.DocumentIds;
		}
	}
}
