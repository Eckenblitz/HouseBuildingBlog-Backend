using HouseBuildingBlog.Domain;

namespace HouseBuildingBlog.Persistence
{
	public interface ITagRepository : IWriteRepository<Tag>, IReadRepository<Tag>
	{
	}
}
