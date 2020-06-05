using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Tags;
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

		public IEnumerable<ITag> Tags { get; set; }

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
			Tags = new List<ITag>(@event.Tags.Select(t => new TagModelMock(t)));
		}

		public void RemoveTag(Guid tagId)
		{
			var tags = Tags.ToList();
			var tag = tags.FirstOrDefault(t => t.TagId.Equals(tagId));
			if (tag != null)
				tags.Remove(tag);

			Tags = tags;
		}
	}
}
