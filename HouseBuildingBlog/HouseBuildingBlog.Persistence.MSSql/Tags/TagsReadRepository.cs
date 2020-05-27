using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence.MSSql.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Tags
{
	public class TagsReadRepository : IReadRepository<Tag>
	{
		DatabaseContext _DBContext;

		public TagsReadRepository(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		public async Task<Tag> GetById(Guid id)
		{
			var model = await _DBContext.FindAsync<TagDBModel>(id);

			if (model != null)
				return model.ConvertToDomain();

			return null;
		}

		public Task<IList<Tag>> Query(Func<Tag, bool> query)
		{
			throw new NotImplementedException();
		}
	}
}
