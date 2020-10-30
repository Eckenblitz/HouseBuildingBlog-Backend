using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Costplan
{
	public interface IWriteCostplanAggregate
	{
		Task<ICostplanItem> CreateCostplanItemAsync(ICostplanItem newItem);

		Task<ICostplanItem> DeleteCostplanItemAsync(Guid costplanItemId);
	}
}
