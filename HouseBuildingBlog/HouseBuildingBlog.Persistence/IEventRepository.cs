using HouseBuildingBlog.Domain;

namespace HouseBuildingBlog.Persistence
{
	public interface IEventRepository : IWriteRepository<Event>, IReadRepository<Event>
	{
	}
}
