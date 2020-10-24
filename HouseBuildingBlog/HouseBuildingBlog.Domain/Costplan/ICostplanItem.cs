using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Costplan
{
    public interface ICostplanItem
    {
        Guid CostplanItemId { get; }

        string Name { get; }

        decimal EstimatedCost { get; }

        int Number { get; }

        IList<Guid> AssignedDocumentIds { get; }
    }
}