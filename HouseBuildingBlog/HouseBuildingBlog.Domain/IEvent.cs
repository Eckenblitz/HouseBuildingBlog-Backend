using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain
{
	public interface IEvent
	{
		Guid EventId { get; }

		string Title { get; }

		DateTime Date { get; }

		ICollection<ITag> Tags { get; }

		string Description { get; }
	}
}
