using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence.MSSql.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Events
{
	public class EventsReadRepository : IReadRepository<Event>
	{
		DatabaseContext _DBContext;

		public EventsReadRepository(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		public async Task<Event> GetById(Guid id)
		{
			var model = await _DBContext.FindAsync<EventDBModel>(id);

			if (model != null)
				return model.ConvertToDomain();

			return null;
		}

		public async Task<IList<Event>> Query(Func<Event, bool> query)
		{
			throw new NotImplementedException();
			//return await _DBContext.Query<EventDBModel>().Where();
		}
	}
}
