using System;

namespace HouseBuildingBlog.Domain
{
	public interface ITag
	{
		Guid TagId { get; }

		string Title { get; }
	}
}