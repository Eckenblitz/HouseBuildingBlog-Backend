using HouseBuildingBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Events.Queries.Contracts
{
	public class EventQueryDto
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public IEnumerable<Guid> Tags { get; set; }

		public string Description { get; set; }

		public static EventQueryDto CreateFrom(IEvent @event)
		{
			return new EventQueryDto()
			{
				EventId = @event.EventId,
				Date = @event.Date,
				Description = @event.Description,
				Title = @event.Title,
				Tags = @event.Tags.Select(t => t.TagId)
			};
		}
	}
}
