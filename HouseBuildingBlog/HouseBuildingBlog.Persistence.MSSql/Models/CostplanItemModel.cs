using HouseBuildingBlog.Domain.Costplan;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class CostplanItemModel : ICostplanItem
	{
		public Guid CostplanItemId { get; }

		public string Name { get; private set; }

		public decimal EstimatedCost { get; private set; }

		public int Number { get; private set; }

		public CostplanItemModel() { }

		public CostplanItemModel(ICostplanItem item)
		{
			CostplanItemId = item.CostplanItemId;
			Update(item);
		}

		public void Update(ICostplanItem item)
		{
			Name = item.Name;
			EstimatedCost = item.EstimatedCost;
			Number = item.Number;
		}
	}
}
