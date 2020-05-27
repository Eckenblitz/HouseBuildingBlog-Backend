using HouseBuildingBlog.Domain;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Tags
{
	public class TagsWriteRepository : IWriteRepository<Tag>
	{
		public Task Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task Save(Tag model)
		{
			throw new NotImplementedException();
		}
	}
}
