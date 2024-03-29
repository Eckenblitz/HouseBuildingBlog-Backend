﻿using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Persistence.MSSql.Documents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Persistence.MSSql.Events
{
	public class EventModel : IEvent
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public IEnumerable<Guid> TagIds => AssignedTags?.Select(et => et.TagId);

		public IEnumerable<Guid> DocumentIds => Documents?.Select(d => d.DocumentId);

		public ICollection<AssignedEventTagModel> AssignedTags { get; set; }

		public ICollection<DocumentModel> Documents { get; set; }

		public EventModel() { }

		public EventModel(IEvent newEvent)
		{
			EventId = newEvent.EventId == Guid.Empty ? Guid.NewGuid() : newEvent.EventId;
			AssignedTags = new List<AssignedEventTagModel>();
			Update(newEvent);
		}

		public void Update(IEvent update)
		{
			Title = update.Title;
			Date = update.Date;
			Description = update.Description;
			UpdateTags(update);
		}

		private void UpdateTags(IEvent update)
		{
			var assignedTags = new List<AssignedEventTagModel>(AssignedTags);

			//Create
			foreach (var tagId in update.TagIds.Except(assignedTags.Select(at => at.TagId)))
				AssignedTags.Add(new AssignedEventTagModel() { EventId = EventId, TagId = tagId });

			//Delete
			foreach (var assignedTag in assignedTags.Where(at => !update.TagIds.Contains(at.TagId)))
				AssignedTags.Remove(assignedTag);
		}
	}
}
