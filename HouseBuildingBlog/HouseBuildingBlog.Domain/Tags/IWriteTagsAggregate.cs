using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Tags
{
	public interface IWriteTagsAggregate
	{
		Task<ITag> CreateTagAsync(ITag tag);

		Task<ITag> UpdateTagAsync(ITag tag);

		Task<ITag> DeleteTagAsync(Guid tagId);
	}
}
