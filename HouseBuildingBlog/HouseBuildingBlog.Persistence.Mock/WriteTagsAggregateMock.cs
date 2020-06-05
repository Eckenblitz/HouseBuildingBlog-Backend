using HouseBuildingBlog.Domain.Tags;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class WriteTagsAggregateMock : WriteTagsAggregateBase
	{
		private readonly TagRepository _tagRepository;

		public WriteTagsAggregateMock(TagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}

		protected override async Task<Guid> CreateTag(ITag tag)
		{
			var existingTag = await _tagRepository.GetById(tag.TagId);
			if (existingTag != null)
				throw new InvalidOperationException("tag already exist");

			await _tagRepository.Save(tag);

			return tag.TagId;
		}

		protected override async Task<ITag> DeleteTag(Guid tagId)
		{
			var existingTag = await _tagRepository.GetById(tagId);
			if (existingTag != null)
				await _tagRepository.Delete(tagId);

			return existingTag;
		}

		protected override async Task<ITag> UpdateTag(ITag tag)
		{
			var existingTag = await _tagRepository.GetById(tag.TagId);
			if (existingTag != null)
				await _tagRepository.Save(tag);

			return existingTag;
		}
	}
}