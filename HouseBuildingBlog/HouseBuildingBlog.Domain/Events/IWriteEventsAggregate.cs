using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Events
{
	public interface IWriteEventsAggregate
	{
		Task<Guid> CreateEventAsync(IEvent newEvent);

		Task<IEvent> UpdateEventAsync(IEvent @event);

		Task<IEvent> DeleteEventAsync(Guid eventId);
	}
}
