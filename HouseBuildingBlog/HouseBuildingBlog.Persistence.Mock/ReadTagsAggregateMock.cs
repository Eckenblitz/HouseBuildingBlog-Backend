using HouseBuildingBlog.Domain.Tags;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class ReadTagsAggregateMock : ReadTagsAggregateBase
	{
		private readonly TagRepository _tagRepository;

		public ReadTagsAggregateMock(TagRepository tagRepository)
		{
			_tagRepository = tagRepository;
		}

		protected override async Task<ITag> Get(Guid tagId)
		{
			return await _tagRepository.GetById(tagId);
		}

		protected override async Task<IEnumerable<ITag>> GetAll()
		{
			return await _tagRepository.Query(t => true);
		}
	}
}