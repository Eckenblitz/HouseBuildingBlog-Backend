using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.MSSql.Events;
using HouseBuildingBlog.Persistence.MSSql.Tags;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog.Persistence.MSSql
{
	public static class IoC
	{
		public static void RegisterMSSQLRepositories(this IServiceCollection services, IConfiguration config)
		{
			var sqlConfig = config.GetSection("MSSqlConfig").Get<MSSQLConfig>();
			services.AddSingleton(sqlConfig);
			services.AddDbContext<DatabaseContext>();

			services.AddTransient<IWriteEventsAggregate, WriteEventsAggregate>();
			services.AddTransient<IReadEventsAggregate, ReadEventsAggregate>();
			services.AddTransient<IWriteTagsAggregate, WriteTagsAggregate>();
			services.AddTransient<IReadTagsAggregate, ReadTagsAggregate>();
		}
	}
}
