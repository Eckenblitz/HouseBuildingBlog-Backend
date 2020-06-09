using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Tags.Commands;
using System;

namespace HouseBuildingBlog.Tags.Models
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

		public Tag(CreateTagCommand command)
		{
			TagId = Guid.NewGuid();
			Title = command.Title;
		}

		public Tag(UpdateTagCommand command)
		{
			TagId = command.TagId;
			Title = command.Title;
		}
	}
}