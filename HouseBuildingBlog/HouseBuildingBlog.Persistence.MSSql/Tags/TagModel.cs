using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.MSSql.Documents;
using HouseBuildingBlog.Persistence.MSSql.Events;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Persistence.MSSql.Tags
{
	public class TagModel : ITag
	{
		public Guid TagId { get; private set; }

		public string Title { get; private set; }

		public ICollection<AssignedEventTagModel> AssignedEvents { get; set; }

		public ICollection<AssignedDocumentTagModel> AssignedDocuments { get; set; }

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