using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Persistence.Mock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock.Repositories
{
	public class EventRepository
	{
		private readonly IList<EventModelMock> _repo = new List<EventModelMock>();

		public Task Delete(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.EventId.Equals(id));
			if (tag != null)
				_repo.Remove(tag);

			return Task.CompletedTask;
		}

		public Task<IEvent> GetById(Guid id)
		{
			IEvent tag = _repo.SingleOrDefault(t => t.EventId.Equals(id));
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
			var @event = _repo.SingleOrDefault(t => t.EventId.Equals(model.EventId));
			if (@event != null)
				@event.Update(model);
			else
				_repo.Add(new EventModelMock(model));

			return Task.CompletedTask;
		}
	}
}
