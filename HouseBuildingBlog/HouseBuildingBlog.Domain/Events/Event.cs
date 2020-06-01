using HouseBuildingBlog.Domain.Tags;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Events
{
	public class Event : IEvent
	{
		public Guid EventId { get; private set; }

		public string Title { get; private set; }

		public DateTime Date { get; private set; }

		public IEnumerable<ITag> Tags { get; private set; }

		public string Description { get; private set; }

		public Event(IEvent @event)
		{
			EventId = @event.EventId;
			Title = @event.Title;
			Date = @event.Date;
			Description = @event.Description;
			Tags = new List<ITag>(@event.Tags);
		}

		public Event(Guid eventId, string title, DateTime date)
		{
			EventId = eventId;
			Title = title;
			Date = date;
			Tags = new List<ITag>();
		}

		public void UpdateTitle(string title)
		{
			Title = title;
		}

		public void UpdateDate(DateTime date)
		{
			Date = date;
		}

		public void UpdateDescription(string description)
		{
			Description = description;
		}

		public void UpdateTags(IEnumerable<ITag> tagIds)
		{
			Tags = new List<ITag>(tagIds);
		}
	}
}
