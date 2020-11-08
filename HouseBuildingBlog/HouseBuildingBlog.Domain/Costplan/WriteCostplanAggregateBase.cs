using HouseBuildingBlog.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Costplan
{
	public abstract class WriteCostplanAggregateBase : IWriteCostplanAggregate
	{
		protected abstract Task SaveChanges();

		protected abstract Task<ICostplanItem> CreateCostplanItem(ICostplanItem newItem);

		public async Task<ICostplanItem> CreateCostplanItemAsync(ICostplanItem newItem)
		{
			var validationResult = CostplanItemValidator.Validate(newItem);

			if (validationResult.Count > 0)
				throw new ValidationException(validationResult);

			ICostplanItem createdItem = await CreateCostplanItem(newItem);
			await SaveChanges();

			return createdItem;
		}

		public async Task<IEnumerable<ICostplanItem>> UpdateCostplanItemAsync(ICostplanItem item)
		{
			var validationResult = CostplanItemValidator.Validate(item);

			if (validationResult.Count > 0)
				throw new ValidationException(validationResult);

			throw new NotImplementedException();
		}

		protected abstract Task<ICostplanItem> DeleteCostplanItem(Guid costplanItemId);

		public async Task<ICostplanItem> DeleteCostplanItemAsync(Guid costplanItemId)
		{
			ICostplanItem deletedItem = await DeleteCostplanItem(costplanItemId);
			await SaveChanges();
			return deletedItem;
		}
	}
}
