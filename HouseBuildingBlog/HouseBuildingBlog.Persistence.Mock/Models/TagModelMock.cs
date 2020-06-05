using HouseBuildingBlog.Domain.Tags;
using System;

namespace HouseBuildingBlog.Persistence.Mock.Models
{
	internal class TagModelMock : ITag
	{
		public TagModelMock(ITag tag)
		{
			TagId = tag.TagId;
			Update(tag);
		}

		public Guid TagId { get; set; }

		public string Title { get; set; }

		public void Update(ITag tag)
		{
			Title = tag.Title;
		}
	}
}
