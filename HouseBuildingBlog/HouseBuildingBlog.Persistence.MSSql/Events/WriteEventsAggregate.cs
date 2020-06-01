using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Persistence.MSSql.Models;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Events
{
	public class WriteEventsAggregate : WriteEventsAggregateBase
	{
		private readonly DatabaseContext _DBContext;

		public WriteEventsAggregate(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		protected override async Task<Guid> CreateEvent(IEvent newEvent)
		{
			var @event = new EventDBModel(newEvent);
			_DBContext.Add(@event);
			await _DBContext.SaveChangesAsync();

			return newEvent.EventId;
		}

		protected override async Task<IEvent> DeleteEvent(Guid eventId)
		{
			var @event = await _DBContext.FindAsync<EventDBModel>(eventId);
			if (@event != null)
			{
				_DBContext.Remove(@event);
				await _DBContext.SaveChangesAsync();
			}
			return @event;
		}

		protected override async Task<IEvent> UpdateEvent(IEvent @event)
		{
			var toUpdate = await _DBContext.FindAsync<EventDBModel>(@event.EventId);
			if (toUpdate != null)
			{
				toUpdate.Update(@event);
				_DBContext.Update(@event);
				await _DBContext.SaveChangesAsync();
				return toUpdate;
			}
			return toUpdate;
		}
	}
}
