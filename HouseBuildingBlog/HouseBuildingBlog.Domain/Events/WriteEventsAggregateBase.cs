using HouseBuildingBlog.Domain.Errors;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Events
{
	public abstract class WriteEventsAggregateBase : IWriteEventsAggregate
	{
		protected abstract Task<IEvent> CreateEvent(IEvent newEvent);

		public Task<IEvent> CreateEventAsync(IEvent newEvent)
		{
			var validationErrors = EventValidator.Validate(newEvent);
			if (validationErrors.Count > 0)
				throw new ValidationException(validationErrors);

			return CreateEvent(newEvent);
		}

		protected abstract Task<IEvent> DeleteEvent(Guid eventId);

		public Task<IEvent> DeleteEventAsync(Guid eventId)
		{
			return DeleteEvent(eventId);
		}

		protected abstract Task<IEvent> UpdateEvent(IEvent @event);

		public Task<IEvent> UpdateEventAsync(IEvent @event)
		{
			var validationErrors = EventValidator.Validate(@event);
			if (validationErrors.Count > 0)
				throw new ValidationException(validationErrors);

			return UpdateEvent(@event);
		}
	}
}
