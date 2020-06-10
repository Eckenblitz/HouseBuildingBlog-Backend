using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.MSSql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Tags
{
	public class ReadTagsAggregate : ReadTagsAggregateBase
	{
		private readonly DatabaseContext _DBContext;

		public ReadTagsAggregate(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		protected override async Task<ITag> Get(Guid tagId)
		{
			return await _DBContext.FindAsync<TagModel>(tagId);
		}

		protected override async Task<IEnumerable<ITag>> GetAll()
		{
			return await _DBContext.Tags.ToListAsync();
		}
	}
}
