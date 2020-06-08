using HouseBuildingBlog.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Events.Commands.Contracts
{
	public class EventCommandDto
	{
		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public IList<Guid> TagIds { get; set; }

		public EventCommandDto() { }

		public EventCommandDto(IEvent @event)
		{
			Title = @event.Title;
			Date = @event.Date;
			Description = @event.Description;
			TagIds = @event.Tags != null ? new List<Guid>(@event.Tags.Select(t => t.TagId)) : null;
		}
	}
}
