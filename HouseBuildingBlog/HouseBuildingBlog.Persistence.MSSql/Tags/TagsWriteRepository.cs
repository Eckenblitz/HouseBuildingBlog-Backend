using HouseBuildingBlog.Domain;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Tags
{
	public class TagsWriteRepository : IWriteRepository<ITag>
	{
		public Task Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task Save(ITag model)
		{
			throw new NotImplementedException();
		}
	}
}
