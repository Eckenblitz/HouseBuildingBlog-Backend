﻿using HouseBuildingBlog.Domain.Events;
using Microsoft.EntityFrameworkCore;
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

		protected override async Task<IEvent> CreateEvent(IEvent newEvent)
		{
			var @event = new EventModel(newEvent);
			_DBContext.Add(@event);
			await _DBContext.SaveChangesAsync();

			return newEvent;
		}

		protected override async Task<IEvent> DeleteEvent(Guid eventId)
		{
			var @event = await _DBContext.Events
				.Include(e => e.AssignedTags)
				.SingleOrDefaultAsync(e => e.EventId.Equals(eventId));
			if (@event != null)
			{
				_DBContext.Remove(@event);
				await _DBContext.SaveChangesAsync();
			}
			return @event;
		}

		protected override async Task<IEvent> UpdateEvent(IEvent @event)
		{
			var toUpdate = await _DBContext.Events
				.Include(e => e.AssignedTags)
				.SingleOrDefaultAsync(e => e.EventId.Equals(@event.EventId));
			if (toUpdate != null)
			{
				toUpdate.Update(@event);
				_DBContext.Events.Update(toUpdate);
				await _DBContext.SaveChangesAsync();
			}
			return toUpdate;
		}
	}
}
