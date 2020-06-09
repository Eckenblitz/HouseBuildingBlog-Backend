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

		IEnumerable<Guid> TagIds { get; }

		string Description { get; }
	}
}
