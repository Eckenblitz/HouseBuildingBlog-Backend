using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Events
{
	public class ReadEventsAggregate : ReadEventsAggregateBase
	{
		private readonly DatabaseContext _DBContext;

		public ReadEventsAggregate(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		protected override async Task<IEvent> Get(Guid eventId)
		{
			return await _DBContext.Events
				.Include(e => e.AssignedTags)
				.Include(e => e.Documents)
				.SingleOrDefaultAsync(e => e.EventId.Equals(eventId));
		}

		protected override async Task<IEnumerable<IEvent>> GetAll()
		{
			return await _DBContext.Events
				.Include(e => e.AssignedTags)
				.Include(e => e.Documents)
				.ToListAsync();
		}

		protected override async Task<IEnumerable<IEvent>> GetEventsByTags(IEnumerable<Guid> tagIds)
		{
			return await _DBContext.Events
				.Include(e => e.AssignedTags)
				.Where(e => e.AssignedTags.Any(et => tagIds.Contains(et.TagId)))
				.Include(e => e.Documents)
				.ToListAsync();
		}

		protected override async Task<IEnumerable<IDocument>> GetAssignedDocuments(Guid eventId)
		{
			var @event = await _DBContext.Events
				.Include(e => e.Documents)
				.Where(e => e.EventId.Equals(eventId))
				.SingleOrDefaultAsync();

			return @event?.Documents;
		}
	}
}
