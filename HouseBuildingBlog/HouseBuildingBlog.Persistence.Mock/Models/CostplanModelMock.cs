using HouseBuildingBlog.Domain.Costplan;
using System.Collections.Generic;

namespace HouseBuildingBlog.Persistence.Mock.Models
{
    public class CostplanModelMock : ICostplan
    {
        public IList<ICostplanItem> Items { get; }
    }
}
