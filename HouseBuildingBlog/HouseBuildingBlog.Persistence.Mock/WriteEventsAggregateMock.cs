using HouseBuildingBlog.Domain.Events;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class WriteEventsAggregateMock : WriteEventsAggregateBase
	{
		private readonly EventRepository _eventRepository;

		public WriteEventsAggregateMock(EventRepository eventRepository)
		{
			_eventRepository = eventRepository;
		}

		protected override async Task<Guid> CreateEvent(IEvent newEvent)
		{
			var existingEvent = await _eventRepository.GetById(newEvent.EventId);
			if (existingEvent != null)
				throw new InvalidOperationException("event already exist");

			await _eventRepository.Save(newEvent);
			return newEvent.EventId;
		}

		protected override async Task<IEvent> DeleteEvent(Guid eventId)
		{
			var existingEvent = await _eventRepository.GetById(eventId);
			if (existingEvent != null)
				await _eventRepository.Delete(eventId);

			return existingEvent;
		}

		protected override async Task<IEvent> UpdateEvent(IEvent @event)
		{
			var existingEvent = await _eventRepository.GetById(@event.EventId);
			if (existingEvent != null)
				await _eventRepository.Save(@event);

			return existingEvent;
		}
	}
}
