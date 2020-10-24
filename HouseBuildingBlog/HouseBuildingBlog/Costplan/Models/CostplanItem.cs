using HouseBuildingBlog.Api.Costplan.Commands.Contracts;
using HouseBuildingBlog.Domain.Costplan;
using System;

namespace HouseBuildingBlog.Api.Costplan.Models
{
    public class CostplanItem : ICostplanItem
    {
        public Guid CostplanItemId { get; }

        public string Name { get; set; }

        public decimal EstimatedCost { get; set; }

        public int Number { get; set; }

        public CostplanItem(Guid costplanItemId, CostplanItemCommandDto dto)
        {
            CostplanItemId = costplanItemId;
            Name = dto.Name;
            EstimatedCost = dto.EstimatedCost;
            Number = dto.Number;
        }
    }
}
