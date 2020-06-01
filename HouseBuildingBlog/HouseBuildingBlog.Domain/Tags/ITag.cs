using System;

namespace HouseBuildingBlog.Domain.Tags
{
	public interface ITag
	{
		Guid TagId { get; }

		string Title { get; }
	}
}