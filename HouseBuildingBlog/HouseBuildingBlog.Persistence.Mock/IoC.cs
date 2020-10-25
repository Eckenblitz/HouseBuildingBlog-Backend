using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.Mock.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog.Persistence.Mock
{
    public static class IoC
    {
        public static void RegisterMockRepositories(this IServiceCollection services)
        {
            services.AddSingleton(new TagRepository());
            services.AddSingleton(new EventRepository());
            services.AddSingleton(new CostplanRepository());

            services.AddTransient<IWriteEventsAggregate, WriteEventsAggregateMock>();
            services.AddTransient<IReadEventsAggregate, ReadEventsAggregateMock>();
            services.AddTransient<IWriteTagsAggregate, WriteTagsAggregateMock>();
            services.AddTransient<IReadTagsAggregate, ReadTagsAggregateMock>();
        }
    }
}
