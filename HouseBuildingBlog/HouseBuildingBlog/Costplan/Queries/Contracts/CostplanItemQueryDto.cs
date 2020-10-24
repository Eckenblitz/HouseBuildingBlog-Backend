using HouseBuildingBlog.Domain.Costplan;
using System;

namespace HouseBuildingBlog.Api.Costplan.Queries.Contracts
{
    public class CostplanItemQueryDto
    {
        public Guid CostplanItemId { get; set; }

        public string Name { get; set; }

        public decimal EstimatedCost { get; set; }

        public int Number { get; set; }

        public CostplanItemQueryDto(ICostplanItem item)
        {
            CostplanItemId = item.CostplanItemId;
            Name = item.Name;
            EstimatedCost = item.EstimatedCost;
            Number = item.Number;
        }
    }
}
