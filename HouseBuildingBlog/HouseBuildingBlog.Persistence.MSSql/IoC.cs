using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.MSSql.Events;
using HouseBuildingBlog.Persistence.MSSql.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog.Persistence.MSSql
{
	public static class IoC
	{
		public static void RegisterMSSQLRepositories(this IServiceCollection services, IConfiguration config)
		{
			//var sqlConfig = config.GetSection("MSSqlConfig").;

			//services.AddDbContext<DatabaseContext>(options =>
			//options.UseSqlServer($"Server={sqlConfig.Server};Database={sqlConfig.DatabaseName};Trusted_Connection={sqlConfig.TrustedConnection}"));
			services.AddDbContext<DatabaseContext>(options =>
				options.UseSqlServer($"Server=localhost\\SQLEXPRESS;Database=HouseBuildingBlog;Trusted_Connection=True"));
			//localhost\SQLEXPRESS
			//Server=VERITAS\\HBB_SQLSERVER

			services.AddTransient<IWriteEventsAggregate, WriteEventsAggregate>();
			services.AddTransient<IReadEventsAggregate, ReadEventsAggregate>();
			services.AddTransient<IWriteTagsAggregate, WriteTagsAggregate>();
			services.AddTransient<IReadTagsAggregate, ReadTagsAggregate>();
		}
	}
}
