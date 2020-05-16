using HouseBuildingBlog.Domain;
using HouseBuildingBlog.Persistence;
using HouseBuildingBlog.Persistence.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog
{
	public static class IoC
	{
		public static void RegisterMockRepositories(this IServiceCollection services)
		{
			services.AddSingleton<IReadRepository<Tag>, TagRepository>();
			services.AddSingleton<IWriteRepository<Tag>, TagRepository>();
			services.AddSingleton<IReadRepository<Event>, EventRepository>();
			services.AddSingleton<IWriteRepository<Event>, EventRepository>();
		}
	}
}
