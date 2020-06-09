using HouseBuildingBlog.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Persistence.Mock.Models
{
	internal class EventModelMock : IEvent
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public IEnumerable<Guid> TagIds { get; set; }

		public string Description { get; set; }

		public EventModelMock(IEvent @event)
		{
			EventId = @event.EventId;
			Update(@event);
		}

		public void Update(IEvent @event)
		{
			Title = @event.Title;
			Date = @event.Date;
			Description = @event.Description;
			UpdateTags(@event.TagIds);
		}

		private void UpdateTags(IEnumerable<Guid> tagIds)
		{
			if (tagIds?.Count() > 0)
				TagIds = new List<Guid>(tagIds);
			else
				TagIds = new List<Guid>();
		}

		public void RemoveTag(Guid tagId)
		{
			var tagIds = TagIds.ToList();
			var tag = tagIds.FirstOrDefault(t => t.Equals(tagId));
			if (tag != null)
				tagIds.Remove(tag);

			TagIds = tagIds;
		}
	}
}
