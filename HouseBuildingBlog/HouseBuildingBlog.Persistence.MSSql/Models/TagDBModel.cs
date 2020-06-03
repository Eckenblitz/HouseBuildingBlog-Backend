using HouseBuildingBlog.Domain.Tags;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class TagDBModel : ITag
	{
		public Guid TagId { get; private set; }

		public string Title { get; private set; }

		public ICollection<EventTags> AssignedEvents { get; set; }

		public TagDBModel() { }

		public TagDBModel(ITag tag)
		{
			Update(tag);
		}

		public void Update(ITag tag)
		{
			TagId = tag.TagId;
			Title = tag.Title;
		}
	}
}