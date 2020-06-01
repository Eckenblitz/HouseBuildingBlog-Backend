using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Events
{
	public interface IReadEventsAggregate
	{
		Task<IEvent> GetAsync(Guid eventId);

		Task<IEnumerable<IEvent>> GetEventsByTagsAsync(IEnumerable<Guid> tagIds);
	}
}
