using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Costplan
{
    public interface IWriteCostplanAggregate
    {
        Task<ICostplanItem> CreateCostplanItem(ICostplanItem newItem);
    }
}
