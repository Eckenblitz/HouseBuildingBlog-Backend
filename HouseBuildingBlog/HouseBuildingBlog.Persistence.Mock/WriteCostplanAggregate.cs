using HouseBuildingBlog.Domain.Costplan;
using HouseBuildingBlog.Persistence.Mock.Repositories;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class WriteCostplanAggregate : WriteCostplanAggregateBase
	{
		private readonly CostplanRepository _repo;

		public WriteCostplanAggregate(CostplanRepository repo)
		{
			_repo = repo;
		}

		protected override async Task<ICostplanItem> CreateCostplanItem(ICostplanItem newItem)
		{
			var existingItem = await _repo.GetById(newItem.CostplanItemId);
			if (existingItem != null)
				throw new InvalidOperationException("costplanitem already exist");

			await _repo.Save(newItem);
			return newItem;
		}

		protected override Task<ICostplanItem> DeleteCostplanItem(Guid costplanItemId)
		{
			var existingItem = _repo.GetById(costplanItemId);
			if (existingItem != null)
				_repo.Delete(costplanItemId);

			return existingItem;
		}
	}
}
