using HouseBuildingBlog.Domain.Costplan;
using HouseBuildingBlog.Persistence.Mock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock.Repositories
{
    public class CostplanRepository
    {
        private readonly IList<CostplanItemModelMock> _repo = new List<CostplanItemModelMock>();

        public Task Delete(Guid id)
        {
            var tag = _repo.SingleOrDefault(t => t.CostplanItemId.Equals(id));
            if (tag != null)
                _repo.Remove(tag);

            return Task.CompletedTask;
        }

        public Task<ICostplanItem> GetById(Guid id)
        {
            ICostplanItem item = _repo.SingleOrDefault(t => t.CostplanItemId.Equals(id));
            return Task.FromResult(item);
        }

        public Task<IList<ICostplanItem>> Query(Func<ICostplanItem, bool> query)
        {
            var queryResult = _repo.Where(t => query(t));
            IList<ICostplanItem> result = new List<ICostplanItem>(queryResult);
            return Task.FromResult(result);
        }

        public Task Save(ICostplanItem model)
        {
            var item = _repo.SingleOrDefault(t => t.CostplanItemId.Equals(model.CostplanItemId));

            if (item != null)
                item.Update(model);
            else
                _repo.Add(new CostplanItemModelMock(model));

            return Task.CompletedTask;
        }
    }
}
