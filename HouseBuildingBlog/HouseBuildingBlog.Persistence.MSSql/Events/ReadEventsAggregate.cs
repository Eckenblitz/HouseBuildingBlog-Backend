using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Persistence.MSSql.Models;
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
			//ToDo include reference (Tags)!!!!!!
			return await _DBContext.Events.FindAsync(eventId);
		}

		protected override async Task<IEnumerable<IEvent>> GetEventsByTags(IEnumerable<Guid> tagIds)
		{
			return await _DBContext.Set<EventDBModel>()
				.Where(e => e.EventTags.Any(et => tagIds.Contains(et.TagId)))
				.ToListAsync();
		}
	}
}
