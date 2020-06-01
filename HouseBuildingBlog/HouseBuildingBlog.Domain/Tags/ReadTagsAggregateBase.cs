using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Tags
{
	public abstract class ReadTagsAggregateBase : IReadTagsAggregate
	{
		protected abstract Task<ITag> Get(Guid tagId);

		public Task<ITag> GetAsync(Guid tagId)
		{
			return Get(tagId);
		}

		protected abstract Task<IEnumerable<ITag>> GetAll();

		public Task<IEnumerable<ITag>> GetAllAsync()
		{
			return GetAll();
		}
	}
}
