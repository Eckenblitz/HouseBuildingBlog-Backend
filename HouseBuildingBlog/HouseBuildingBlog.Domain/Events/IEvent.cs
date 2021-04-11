using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Events
{
	public interface IEvent
	{
		Guid EventId { get; }

		string Title { get; }

		DateTime Date { get; }

		string Description { get; }

		IEnumerable<Guid> TagIds { get; }

		IEnumerable<Guid> DocumentIds { get; }
	}
}
