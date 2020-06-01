using HouseBuildingBlog.Domain.Tags;
using System;

namespace HouseBuildingBlog.Tags.Queries.Contracts
{
	public class TagQueryDto
	{
		public Guid TagId { get; set; }

		public string Title { get; set; }

		public static TagQueryDto From(Tag tag)
		{
			return new TagQueryDto()
			{
				TagId = tag.TagId,
				Title = tag.Title
			};
		}
	}
}
