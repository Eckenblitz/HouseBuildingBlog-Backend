using HouseBuildingBlog.Domain.Events;
using System;

namespace HouseBuildingBlog.Events.Queries.Contracts
{
	public class SimpleEventQueryDto
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public static SimpleEventQueryDto CreateFrom(IEvent @event)
		{
			return new SimpleEventQueryDto()
			{
				EventId = @event.EventId,
				Date = @event.Date,
				Title = @event.Title
			};
		}
	}
}
