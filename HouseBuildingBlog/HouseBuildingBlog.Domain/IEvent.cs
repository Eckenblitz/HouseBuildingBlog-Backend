using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain
{
	public interface IEvent
	{
		Guid Id { get; }

		string Title { get; }

		DateTime Date { get; }

		IList<IContentBlock> ContentBlocks { get; }

		IList<ITag> Tags { get; }
	}
}
