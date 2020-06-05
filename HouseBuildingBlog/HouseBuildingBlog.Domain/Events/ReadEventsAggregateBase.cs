using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Events
{
	public abstract class ReadEventsAggregateBase : IReadEventsAggregate
	{
		protected abstract Task<IEvent> Get(Guid eventId);

		public Task<IEvent> GetAsync(Guid eventId)
		{
			return Get(eventId);
		}

		protected abstract Task<IEnumerable<IEvent>> GetEventsByTags(IEnumerable<Guid> tagIds);

		public Task<IEnumerable<IEvent>> FilterByTags(IEnumerable<Guid> tagIds)
		{
			return GetEventsByTags(tagIds);
		}

		protected abstract Task<IEnumerable<IEvent>> GetAll();

		public Task<IEnumerable<IEvent>> GetAllAsync()
		{
			return GetAll();
		}
	}
}
