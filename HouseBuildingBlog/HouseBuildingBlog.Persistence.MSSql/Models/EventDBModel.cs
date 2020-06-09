using HouseBuildingBlog.Domain.Events;
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

		public IEnumerable<Guid> TagIds => EventTags?.Select(et => et.Tag.TagId);

		public ICollection<AssignedTags> EventTags { get; set; }

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
			EventTags = new List<AssignedTags>();
			foreach (var tag in @event.TagIds)
				EventTags.Add(new AssignedTags() { EventId = EventId, TagId = tag });
		}
	}
}
