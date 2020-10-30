using HouseBuildingBlog.Domain.Validation;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Costplan
{
	public abstract class WriteCostplanAggregateBase : IWriteCostplanAggregate
	{
		protected abstract Task<ICostplanItem> CreateCostplanItem(ICostplanItem newItem);

		public Task<ICostplanItem> CreateCostplanItemAsync(ICostplanItem newItem)
		{
			var validationResult = CostplanItemValidator.Validate(newItem);

			if (validationResult.Count > 0)
				throw new ValidationException(validationResult);

			return CreateCostplanItem(newItem);
		}

		protected abstract Task<ICostplanItem> DeleteCostplanItem(Guid costplanItemId);

		public Task<ICostplanItem> DeleteCostplanItemAsync(Guid costplanItemId)
		{
			return DeleteCostplanItem(costplanItemId);
		}
	}
}
