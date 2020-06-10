using HouseBuildingBlog.Domain.Events;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class EventModel : IEvent
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public IEnumerable<Guid> TagIds { get; set; }

		public ICollection<AssignedTagsModel> EventTags { get; set; }

		public EventModel() { }

		public EventModel(IEvent newEvent)
		{
			EventId = newEvent.EventId == Guid.Empty ? Guid.NewGuid() : newEvent.EventId;
			Update(newEvent);
		}

		public void Update(IEvent @event)
		{
			Title = @event.Title;
			Date = @event.Date;
			Description = @event.Description;
			EventTags = new List<AssignedTagsModel>();
			foreach (var tag in @event.TagIds)
				EventTags.Add(new AssignedTagsModel() { EventId = EventId, TagId = tag });
		}
	}
}
