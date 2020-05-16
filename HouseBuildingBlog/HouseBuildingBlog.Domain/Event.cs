using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain
{
	public class Event
	{
		public Guid EventId { get; private set; }

		public string Title { get; private set; }

		public DateTime Date { get; private set; }

		public IList<Guid> Tags { get; private set; }

		public string Description { get; private set; }

		public Event(Guid eventId, string title, DateTime date)
		{
			EventId = eventId;
			Title = title;
			Date = date;
			Tags = new List<Guid>();
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

		public void UpdateTags(IList<Guid> tagIds)
		{
			Tags = new List<Guid>(tagIds);
		}
	}
}
