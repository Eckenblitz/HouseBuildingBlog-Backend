using HouseBuildingBlog.Domain;

namespace HouseBuildingBlog.Persistence
{
	interface ITagRepository : IWriteRepository<Tag>, IReadRepository<Tag>
	{
	}
}
