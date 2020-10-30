using HouseBuildingBlog.Domain.Costplan;
using HouseBuildingBlog.Persistence.MSSql.Models;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Costplan
{
	public class WriteCostplanAggregate : WriteCostplanAggregateBase
	{
		private readonly DatabaseContext _DBContext;

		public WriteCostplanAggregate(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		protected override async Task<ICostplanItem> CreateCostplanItem(ICostplanItem newItem)
		{
			var item = new CostplanItemModel(newItem);
			_DBContext.Add(item);
			await _DBContext.SaveChangesAsync();

			return item;
		}
	}
}
