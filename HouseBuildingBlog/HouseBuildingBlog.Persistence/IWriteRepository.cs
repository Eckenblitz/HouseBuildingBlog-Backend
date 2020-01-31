using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence
{
	public interface IWriteRepository<TModel>
	{
		Task Save(TModel model);

		Task Delete(Guid id);
	}
}
