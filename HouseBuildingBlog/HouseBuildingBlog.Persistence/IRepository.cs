using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence
{
	public interface IRepository<TModel>
	{
		Task<TModel> Get(Guid id);

		Task<IList<TModel>> Query(Func<TModel, bool> query);

		Task Save(TModel model);
	}
}
