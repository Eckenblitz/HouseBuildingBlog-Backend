using HouseBuildingBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class EventRepository : IReadRepository<IEvent>, IWriteRepository<IEvent>
	{
		private readonly IList<IEvent> _repo = new List<IEvent>();

		public Task Delete(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.EventId.Equals(id));
			if (tag != null)
				_repo.Remove(tag);

			return Task.CompletedTask;
		}

		public Task<IEvent> GetById(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.EventId.Equals(id));
			return Task.FromResult(tag);
		}

		public Task<IList<IEvent>> Query(Func<IEvent, bool> query)
		{
			var queryResult = _repo.Where(t => query(t));
			IList<IEvent> result = new List<IEvent>(queryResult);
			return Task.FromResult(result);
		}

		public Task Save(IEvent model)
		{
			var tag = _repo.SingleOrDefault(t => t.EventId.Equals(model.EventId));
			if (tag != null)
				tag = model;
			else
				_repo.Add(model);
			return Task.CompletedTask;
		}
	}
}
