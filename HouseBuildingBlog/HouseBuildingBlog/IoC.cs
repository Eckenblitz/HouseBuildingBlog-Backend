﻿using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using HouseBuildingBlog.Persistence.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog
{
	public static class IoC
	{
		public static void RegisterMockRepositories(this IServiceCollection services)
		{
			var tagRepo = new TagRepository();
			var eventRepo = new EventRepository();
			services.AddSingleton(typeof(IReadRepository<Tag>),tagRepo);
			services.AddSingleton(typeof(IWriteRepository<Tag>), tagRepo);
			services.AddSingleton(typeof(IReadRepository<Event>), eventRepo);
			services.AddSingleton(typeof(IWriteRepository<Event>), eventRepo);
		}
	}
}
