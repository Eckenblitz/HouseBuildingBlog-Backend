using HouseBuildingBlog.Domain;

namespace HouseBuildingBlog.Persistence
{
	public interface IDocumentRepository : IWriteRepository<Document>, IReadRepository<Document>
	{
	}
}
