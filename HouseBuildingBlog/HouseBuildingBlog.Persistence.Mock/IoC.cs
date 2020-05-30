using HouseBuildingBlog.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog.Persistence.Mock
{
	public static class IoC
	{
		public static void RegisterMockRepositories(this IServiceCollection services)
		{
			var tagRepo = new TagRepository();
			var eventRepo = new EventRepository();
			services.AddSingleton(typeof(IReadRepository<ITag>), tagRepo);
			services.AddSingleton(typeof(IWriteRepository<ITag>), tagRepo);
			services.AddSingleton(typeof(IReadRepository<IEvent>), eventRepo);
			services.AddSingleton(typeof(IWriteRepository<IEvent>), eventRepo);
		}
	}
}
