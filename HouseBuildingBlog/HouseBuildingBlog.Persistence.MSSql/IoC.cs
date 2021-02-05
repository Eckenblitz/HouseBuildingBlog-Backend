using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.MSSql.Documents;
using HouseBuildingBlog.Persistence.MSSql.Events;
using HouseBuildingBlog.Persistence.MSSql.Files;
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
			//Events
			services.AddTransient<IWriteEventsAggregate, WriteEventsAggregate>();
			services.AddTransient<IReadEventsAggregate, ReadEventsAggregate>();
			//Tags
			services.AddTransient<IWriteTagsAggregate, WriteTagsAggregate>();
			services.AddTransient<IReadTagsAggregate, ReadTagsAggregate>();
			//Documents
			services.AddTransient<IWriteDocumentsRepository, WriteDocumentsRepository>();
			services.AddTransient<IReadDocumentsRepository, ReadDocumentsRepository>();
			services.AddTransient<IWriteFileRepository<IDocumentFile>, WriteDocumentFileRepository>();
			services.AddTransient<IReadFileRepository<IDocumentFile>, ReadDocumentFileRepository>();
		}
	}
}
