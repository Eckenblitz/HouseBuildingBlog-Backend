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

		public IEnumerable<Guid> TagIds { get; set; }

		public string Description { get; set; }

		public TestEvent() { }

		public TestEvent(IEvent @event)
		{
			EventId = @event.EventId;
			Title = @event.Title;
			Date = @event.Date;
			TagIds = @event.TagIds != null ? new List<Guid>(@event.TagIds) : new List<Guid>();
			Description = @event.Description;
		}
	}
}
