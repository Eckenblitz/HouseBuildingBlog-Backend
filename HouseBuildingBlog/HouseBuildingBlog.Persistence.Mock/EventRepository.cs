using HouseBuildingBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class EventRepository : IEventRepository
	{
		private readonly IList<Event> _repo = new List<Event>();

		public Task Delete(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.EventId.Equals(id));
			if (tag != null)
				_repo.Remove(tag);

			return Task.CompletedTask;
		}

		public Task<Event> Get(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.EventId.Equals(id));
			return Task.FromResult(tag);
		}

		public Task<IList<Event>> Query(Func<Event, bool> query)
		{
			var queryResult = _repo.Where(t => query(t));
			IList<Event> result = new List<Event>(queryResult);
			return Task.FromResult(result);
		}

		public Task Save(Event model)
		{
			var tag = _repo.SingleOrDefault(t => t.EventId.Equals(model.EventId));
			tag = model;
			return Task.CompletedTask;
		}
	}
}
