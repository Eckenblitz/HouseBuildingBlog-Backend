using HouseBuildingBlog.Domain.Costplan;
using HouseBuildingBlog.Persistence.Mock.Repositories;
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

        protected override Task<ICostplanItem> CreateCostplanItem(ICostplanItem newItem)
        {
            _repo.Save(newItem);
            return Task.FromResult(newItem);
        }
    }
}
