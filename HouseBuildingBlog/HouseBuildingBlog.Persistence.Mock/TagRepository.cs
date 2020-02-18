using HouseBuildingBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class TagRepository : ITagRepository
	{
		private readonly IList<Tag> _repo = new List<Tag>();

		public Task Delete(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.TagId.Equals(id));
			if (tag != null)
				_repo.Remove(tag);

			return Task.CompletedTask;
		}

		public Task<Tag> Get(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.TagId.Equals(id));
			return Task.FromResult(tag);
		}

		public Task<IList<Tag>> Query(Func<Tag, bool> query)
		{
			var queryResult = _repo.Where(t => query(t));
			IList<Tag> result = new List<Tag>(queryResult);
			return Task.FromResult(result);
		}

		public Task Save(Tag model)
		{
			var tag = _repo.SingleOrDefault(t => t.TagId.Equals(model.TagId));
			tag = model;
			return Task.CompletedTask;
		}
	}
}
