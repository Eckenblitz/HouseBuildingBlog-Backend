using HouseBuildingBlog.Domain.Tags;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Events
{
	public interface IEvent
	{
		Guid EventId { get; }

		string Title { get; }

		DateTime Date { get; }

		IEnumerable<ITag> Tags { get; }

		string Description { get; }
	}
}
