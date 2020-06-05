using HouseBuildingBlog.Domain.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class TagRepository
	{
		private readonly IList<ITag> _repo = new List<ITag>();

		public Task Delete(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.TagId.Equals(id));
			if (tag != null)
				_repo.Remove(tag);

			return Task.CompletedTask;
		}

		public Task<ITag> GetById(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.TagId.Equals(id));
			return Task.FromResult(tag);
		}

		public Task<IList<ITag>> Query(Func<ITag, bool> query)
		{
			var queryResult = _repo.Where(t => query(t));
			IList<ITag> result = new List<ITag>(queryResult);
			return Task.FromResult(result);
		}

		public Task Save(ITag model)
		{
			var tag = _repo.SingleOrDefault(t => t.TagId.Equals(model.TagId));

			if (tag != null)
				tag = model;
			else
				_repo.Add(model);

			return Task.CompletedTask;
		}
	}
}
