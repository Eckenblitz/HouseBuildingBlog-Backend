using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Persistence.MSSql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
			UpdateAssignedTags(@event.EventId, newEvent.TagIds);
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
				UpdateAssignedTags(toUpdate.EventId, @event.TagIds);
				await _DBContext.SaveChangesAsync();
				return toUpdate;
			}
			return toUpdate;
		}

		private void UpdateAssignedTags(Guid eventId, IEnumerable<Guid> tagIds)
		{
			var assignedTags = _DBContext.AssignedEventTags.Where(at => at.EventId.Equals(eventId));

			//Create
			foreach (var tagId in tagIds.Except(assignedTags.Select(at => at.TagId)))
				_DBContext.Add(new AssignedTagsModel() { EventId = eventId, TagId = tagId });

			//Delete
			foreach (var assignedTag in assignedTags.Where(at => !tagIds.Contains(at.TagId)))
				_DBContext.AssignedEventTags.Remove(assignedTag);
		}
	}
}
