using HouseBuildingBlog.Persistence;
using HouseBuildingBlog.Persistence.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog
{
	public static class IoC
	{
		public static void RegisterMockRepositories(this IServiceCollection services)
		{
			services.AddSingleton<ITagRepository, TagRepository>();
			services.AddSingleton<IEventRepository, EventRepository>();
			services.AddSingleton<IDocumentRepository, DocumentRepository>();
		}
	}
}
