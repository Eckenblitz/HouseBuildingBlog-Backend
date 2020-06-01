using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Tags;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class EventDBModel : IEvent
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public IEnumerable<ITag> Tags => EventTags?.Select(et => et.Tag);

		public ICollection<EventTags> EventTags { get; set; }

		public EventDBModel() { }

		public EventDBModel(IEvent newEvent)
		{
			EventId = newEvent.EventId == Guid.Empty ? Guid.NewGuid() : newEvent.EventId;
			Update(newEvent);
		}

		public void Update(IEvent @event)
		{
			Title = @event.Title;
			Date = @event.Date;
			Description = @event.Description;
			EventTags = new List<EventTags>();
			foreach (var tag in @event.Tags)
				EventTags.Add(new EventTags() { EventId = EventId, TagId = tag.TagId });
		}
	}
}
