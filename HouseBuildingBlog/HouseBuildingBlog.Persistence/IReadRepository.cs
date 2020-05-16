using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence
{
	public interface IReadRepository<TModel>
	{
		Task<TModel> GetById(Guid id);

		Task<IList<TModel>> Query(Func<TModel, bool> query);
	}
}
