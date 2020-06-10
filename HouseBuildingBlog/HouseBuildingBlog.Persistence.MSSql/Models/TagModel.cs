using HouseBuildingBlog.Domain.Tags;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class TagModel : ITag
	{
		public Guid TagId { get; private set; }

		public string Title { get; private set; }

		public ICollection<AssignedTagsModel> AssignedEvents { get; set; }

		public TagModel() { }

		public TagModel(ITag tag)
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