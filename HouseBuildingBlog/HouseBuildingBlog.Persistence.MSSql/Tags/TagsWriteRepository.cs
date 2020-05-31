using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence.MSSql.Models;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Tags
{
	public class TagsWriteRepository : IWriteRepository<ITag>
	{
		private readonly DatabaseContext _DBContext;

		public TagsWriteRepository(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		public async Task Delete(Guid id)
		{
			var tag = await _DBContext.FindAsync<TagDBModel>(id);
			if (tag != null)
			{
				_DBContext.Remove(tag);
				await _DBContext.SaveChangesAsync();
			}
		}

		public async Task Save(ITag model)
		{
			var tag = await _DBContext.FindAsync<TagDBModel>(model.TagId);
			if(tag != null)
			{
				tag.Update(model);
				_DBContext.Update(tag);
			}
			else
			{
				tag = new TagDBModel(model);
				tag.Update(tag);
				_DBContext.Add(tag);
			}
			await _DBContext.SaveChangesAsync();
		}
	}
}
