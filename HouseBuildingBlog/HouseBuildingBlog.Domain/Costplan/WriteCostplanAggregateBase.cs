using HouseBuildingBlog.Domain.Validation;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Costplan
{
    public abstract class WriteCostplanAggregateBase : IWriteCostplanAggregate
    {
        protected abstract Task<ICostplanItem> CreateCostplan(ICostplanItem newItem);

        public Task<ICostplanItem> CreateCostplanItem(ICostplanItem newItem)
        {
            var validationResult = CostplanItemValidator.Validate(newItem);

            if (validationResult.Count > 0)
                throw new ValidationException(validationResult);

            return CreateCostplan(newItem);
        }
    }
}
