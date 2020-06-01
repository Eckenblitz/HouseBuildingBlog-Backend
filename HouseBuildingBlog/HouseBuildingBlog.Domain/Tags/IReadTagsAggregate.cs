using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Tags
{
	public interface IReadTagsAggregate
	{
		Task<ITag> GetAsync(Guid tagId);

		Task<IEnumerable<ITag>> GetAllAsync();
	}
}
