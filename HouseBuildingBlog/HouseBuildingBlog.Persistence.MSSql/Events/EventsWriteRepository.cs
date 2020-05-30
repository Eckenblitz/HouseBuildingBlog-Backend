using HouseBuildingBlog.Domain;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Events
{
	public class EventsWriteRepository : IWriteRepository<IEvent>
	{
		public Task Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task Save(IEvent model)
		{
			throw new NotImplementedException();
		}
	}
}
