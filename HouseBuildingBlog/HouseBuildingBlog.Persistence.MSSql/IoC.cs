﻿using HouseBuildingBlog.Domain;
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
				options.UseSqlServer($"Server=VERITAS\\HBB_SQLSERVER;Database=HouseBuildingBlog;Trusted_Connection=True"));

			services.AddTransient<IReadRepository<IEvent>, EventsReadRepository>();
			services.AddTransient<IWriteRepository<IEvent>, EventsWriteRepository>();
			services.AddTransient<IReadRepository<ITag>, TagsReadRepository>();
			services.AddTransient<IWriteRepository<ITag>, TagsWriteRepository>();
		}
	}
}
