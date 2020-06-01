using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Tags
{
	public interface IWriteTagsAggregate
	{
		Task<Guid> CreateTagAsync(ITag tag);

		Task<ITag> UpdateTagAsync(ITag tag);

		Task<ITag> DeleteTagAsync(Guid tagId);
	}
}
