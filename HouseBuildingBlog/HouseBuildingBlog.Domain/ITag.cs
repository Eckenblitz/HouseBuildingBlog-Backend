using System;

namespace HouseBuildingBlog.Domain
{
	public interface ITag
	{
		Guid Id { get; }

		string Title { get; }
	}
}