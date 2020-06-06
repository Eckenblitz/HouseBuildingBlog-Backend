using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.Mock.Models;
using HouseBuildingBlog.Persistence.Mock.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class WriteTagsAggregateMock : WriteTagsAggregateBase
	{
		private readonly TagRepository _tagRepository;
		private readonly EventRepository _eventRepository;

		public WriteTagsAggregateMock(TagRepository tagRepository, EventRepository eventRepository)
		{
			_tagRepository = tagRepository;
			_eventRepository = eventRepository;
		}

		protected override async Task<ITag> CreateTag(ITag tag)
		{
			var existingTag = await _tagRepository.GetById(tag.TagId);
			if (existingTag != null)
				throw new InvalidOperationException("tag already exist");

			await _tagRepository.Save(tag);

			return tag;
		}

		protected override async Task<ITag> DeleteTag(Guid tagId)
		{
			var existingTag = await _tagRepository.GetById(tagId);
			if (existingTag != null)
			{
				await _tagRepository.Delete(tagId);
				var eventsWithTag = await _eventRepository.Query(e => e.Tags.Any(t => t.TagId.Equals(tagId)));
				foreach (var @event in eventsWithTag)
				{
					var eventMock = new EventModelMock(@event);
					eventMock.RemoveTag(tagId);
					await _eventRepository.Save(eventMock);
				}
			}

			return existingTag;
		}

		protected override async Task<ITag> UpdateTag(ITag tag)
		{
			var existingTag = await _tagRepository.GetById(tag.TagId);
			if (existingTag != null)
				await _tagRepository.Save(tag);

			return tag;
		}
	}
}