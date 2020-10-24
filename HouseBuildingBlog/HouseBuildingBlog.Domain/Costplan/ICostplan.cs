using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Costplan
{
    public interface ICostplan
    {
        IList<ICostplanItem> Items { get; }
    }
}
