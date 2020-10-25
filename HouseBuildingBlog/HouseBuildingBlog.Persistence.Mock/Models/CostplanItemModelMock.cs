using HouseBuildingBlog.Domain.Costplan;
using System;

namespace HouseBuildingBlog.Persistence.Mock.Models
{
    public class CostplanItemModelMock : ICostplanItem
    {
        public Guid CostplanItemId { get; set; }

        public string Name { get; set; }

        public decimal EstimatedCost { get; set; }

        public int Number { get; set; }

        public CostplanItemModelMock(ICostplanItem model)
        {
            CostplanItemId = model.CostplanItemId;
            Update(model);
        }

        public void Update(ICostplanItem model)
        {
            Name = model.Name;
            EstimatedCost = model.EstimatedCost;
            Number = model.Number;
        }
    }
}
