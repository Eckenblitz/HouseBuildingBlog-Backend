using System;

namespace HouseBuildingBlog.Domain.Tags
{
	public class Tag : ITag
	{
		public Guid TagId { get; private set; }

		public string Title { get; private set; }

		public Tag(ITag tag)
		{
			TagId = tag.TagId;
			Title = tag.Title;
		}

		public Tag(Guid tagId, string title)
		{
			TagId = tagId;
			Title = title;
		}

		public void UpdateTitle(string title)
		{
			Title = title;
		}
	}
}