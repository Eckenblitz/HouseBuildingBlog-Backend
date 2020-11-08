using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Costplan
{
	public interface IWriteCostplanAggregate
	{
		Task<ICostplanItem> CreateCostplanItemAsync(ICostplanItem newItem);

		Task<IEnumerable<ICostplanItem>> UpdateCostplanItemAsync(ICostplanItem item);

		Task<ICostplanItem> DeleteCostplanItemAsync(Guid costplanItemId);
	}
}
