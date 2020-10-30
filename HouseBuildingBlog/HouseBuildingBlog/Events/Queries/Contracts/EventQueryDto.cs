using HouseBuildingBlog.Domain.Events;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Events.Queries.Contracts
{
	public class EventQueryDto
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public IEnumerable<Guid> TagIds { get; set; }

		public string Description { get; set; }

		public EventQueryDto(IEvent @event)
		{
			EventId = @event.EventId;
			Date = @event.Date;
			Description = @event.Description;
			Title = @event.Title;
			TagIds = @event.TagIds != null ? @event.TagIds : null;
		}

	}
}
