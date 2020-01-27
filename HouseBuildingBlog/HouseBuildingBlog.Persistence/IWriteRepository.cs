using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence
{
    public interface IWriteRepository<TModel>
    {
        Task<TModel> Get(Guid id);

        Task Save(TModel model);

        Task Delete(Guid id);
    }
}
