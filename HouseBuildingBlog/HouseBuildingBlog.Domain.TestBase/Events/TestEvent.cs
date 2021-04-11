using HouseBuildingBlog.Domain.Events;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.TestBase.Events
{
	public class TestEvent : IEvent
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public IEnumerable<Guid> TagIds { get; set; }

		public IEnumerable<Guid> DocumentIds { get; set; }

		public TestEvent() { }

		public TestEvent(IEvent @event)
		{
			EventId = @event.EventId;
			Title = @event.Title;
			Date = @event.Date;
			Description = @event.Description;
			TagIds = @event.TagIds != null ? new List<Guid>(@event.TagIds) : new List<Guid>();
			DocumentIds = @event.DocumentIds != null ? new List<Guid>(@event.DocumentIds) : new List<Guid>();
		}
	}
}
