using HouseBuildingBlog.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class EventModel : IEvent
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public IEnumerable<Guid> TagIds => AssignedTags?.Select(et => et.TagId);

		public ICollection<AssignedTagsModel> AssignedTags { get; set; }

		public EventModel() { }

		public EventModel(IEvent newEvent)
		{
			EventId = newEvent.EventId == Guid.Empty ? Guid.NewGuid() : newEvent.EventId;
			AssignedTags = new List<AssignedTagsModel>();
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
			var assignedTags = new List<AssignedTagsModel>(AssignedTags);

			//Create
			foreach (var tagId in update.TagIds.Except(assignedTags.Select(at => at.TagId)))
				AssignedTags.Add(new AssignedTagsModel() { EventId = EventId, TagId = tagId });

			//Delete
			foreach (var assignedTag in assignedTags.Where(at => !update.TagIds.Contains(at.TagId)))
				AssignedTags.Remove(assignedTag);
		}
	}
}
