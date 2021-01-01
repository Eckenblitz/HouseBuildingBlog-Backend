using HouseBuildingBlog.Domain.Errors;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Tags
{
	public abstract class WriteTagsAggregateBase : IWriteTagsAggregate
	{
		protected abstract Task<ITag> CreateTag(ITag tag);

		public Task<ITag> CreateTagAsync(ITag tag)
		{
			var validationErrors = TagValidator.Validate(tag);
			if (validationErrors.Count > 0)
				throw new ValidationException(validationErrors);

			return CreateTag(tag);
		}

		protected abstract Task<ITag> DeleteTag(Guid tagId);

		public Task<ITag> DeleteTagAsync(Guid tagId)
		{
			return DeleteTag(tagId);
		}

		protected abstract Task<ITag> UpdateTag(ITag tag);

		public Task<ITag> UpdateTagAsync(ITag tag)
		{
			var validationErrors = TagValidator.Validate(tag);
			if (validationErrors.Count > 0)
				throw new ValidationException(validationErrors);

			return UpdateTag(tag);
		}
	}
}
