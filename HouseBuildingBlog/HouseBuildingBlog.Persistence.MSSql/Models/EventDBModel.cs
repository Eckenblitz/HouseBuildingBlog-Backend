using HouseBuildingBlog.Domain;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class EventDBModel : IEvent
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public ICollection<ITag> Tags { get; set; }

		public ICollection<EventTags> EventTags { get; set; }

		public Event ConvertToDomain()
		{
			var @event = new Event(EventId, Title, Date);
			@event.UpdateDescription(Description);

			return @event;
		}
	}
}
