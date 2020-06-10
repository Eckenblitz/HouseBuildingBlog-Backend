using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.MSSql.Models;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Tags
{
	public class WriteTagsAggregate : WriteTagsAggregateBase
	{
		private readonly DatabaseContext _DBContext;

		public WriteTagsAggregate(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		protected override async Task<ITag> CreateTag(ITag tag)
		{
			var newTag = new TagModel(tag);
			_DBContext.Add(newTag);
			await _DBContext.SaveChangesAsync();

			return newTag;
		}

		protected override async Task<ITag> DeleteTag(Guid tagId)
		{
			var tag = await _DBContext.FindAsync<TagModel>(tagId);

			if (tag != null)
			{
				_DBContext.Remove(tag);
				await _DBContext.SaveChangesAsync();
			}

			return tag;
		}

		protected override async Task<ITag> UpdateTag(ITag tag)
		{
			var toUpdate = await _DBContext.FindAsync<TagModel>(tag.TagId);

			if (toUpdate != null)
			{
				toUpdate.Update(tag);
				_DBContext.Update(toUpdate);
				await _DBContext.SaveChangesAsync();
			}

			return toUpdate;
		}
	}
}
