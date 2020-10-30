using HouseBuildingBlog.Domain.Costplan;
using HouseBuildingBlog.Persistence.MSSql.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

		protected async override Task<ICostplanItem> DeleteCostplanItem(Guid costplanItemId)
		{
			var existingItem = await _DBContext.CostplanItems
				.SingleOrDefaultAsync(e => e.CostplanItemId.Equals(costplanItemId));
			if (existingItem != null)
			{
				_DBContext.Remove(existingItem);
				await _DBContext.SaveChangesAsync();
			}
			return existingItem;
		}
	}
}
