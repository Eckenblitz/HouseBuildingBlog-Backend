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

		protected override async Task SaveChanges()
		{
			await _DBContext.SaveChangesAsync();
		}

		protected override Task<ICostplanItem> CreateCostplanItem(ICostplanItem newItem)
		{
			ICostplanItem item = new CostplanItemModel(newItem);
			_DBContext.Add(item);

			return Task.FromResult(item);
		}

		protected async override Task<ICostplanItem> DeleteCostplanItem(Guid costplanItemId)
		{
			var existingItem = await _DBContext.CostplanItems
				.SingleOrDefaultAsync(e => e.CostplanItemId.Equals(costplanItemId));
			if (existingItem != null)
			{
				_DBContext.Remove(existingItem);
			}
			return existingItem;
		}
	}
}
