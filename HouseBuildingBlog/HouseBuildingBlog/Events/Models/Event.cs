﻿using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Events.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Events.Models
{
	public class Event : IEvent
	{
		public Guid EventId { get; private set; }

		public string Title { get; private set; }

		public DateTime Date { get; private set; }

		public IEnumerable<Guid> TagIds { get; private set; }

		public string Description { get; private set; }

		public Event(IEvent @event)
		{
			EventId = @event.EventId;
			Title = @event.Title;
			Date = @event.Date;
			Description = @event.Description;
			UpdateTags(@event.TagIds);
		}

		public Event(CreateEventCommand command)
		{
			EventId = Guid.NewGuid();
			Title = command.Data.Title;
			Date = command.Data.Date;
			Description = command.Data.Description;
			UpdateTags(command.Data.TagIds);
		}

		public Event(UpdateEventCommand command)
		{
			EventId = command.EventId;
			Title = command.Data.Title;
			Date = command.Data.Date;
			Description = command.Data.Description;
			UpdateTags(command.Data.TagIds);
		}

		private void UpdateTags(IEnumerable<Guid> tagIds)
		{
			if (tagIds?.Count() > 0)
				TagIds = new List<Guid>(tagIds);
			else
				TagIds = new List<Guid>();
		}
	}
}