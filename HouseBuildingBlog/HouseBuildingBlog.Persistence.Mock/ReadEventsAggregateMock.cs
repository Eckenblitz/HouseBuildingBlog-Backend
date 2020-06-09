using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Persistence.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class ReadEventsAggregateMock : ReadEventsAggregateBase
	{
		private readonly EventRepository _eventRepository;

		public ReadEventsAggregateMock(EventRepository eventRepository)
		{
			_eventRepository = eventRepository;
		}

		protected override async Task<IEvent> Get(Guid eventId)
		{
			return await _eventRepository.GetById(eventId);
		}

		protected override async Task<IEnumerable<IEvent>> GetAll()
		{
			return await _eventRepository.Query(e => true);
		}

		protected override async Task<IEnumerable<IEvent>> GetEventsByTags(IEnumerable<Guid> tagIds)
		{
			var tagIdList = tagIds.ToList();
			return await _eventRepository.Query(e => e.TagIds.Intersect(tagIds).Count() > 0);
		}
	}
}