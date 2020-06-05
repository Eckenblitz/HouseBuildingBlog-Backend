using HouseBuildingBlog.Domain.Events;
using HouseBuildingBlog.Domain.Tags;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog.Persistence.Mock
{
	public static class IoC
	{
		public static void RegisterMockRepositories(this IServiceCollection services)
		{
			var tagRepo = new TagRepository();
			var eventRepo = new EventRepository();
			services.AddSingleton(tagRepo);
			services.AddSingleton(eventRepo);

			services.AddTransient<IWriteEventsAggregate, WriteEventsAggregateMock>();
			services.AddTransient<IReadEventsAggregate, ReadEventsAggregateMock>();
			services.AddTransient<IWriteTagsAggregate, WriteTagsAggregateMock>();
			services.AddTransient<IReadTagsAggregate, ReadTagsAggregateMock>();
		}
	}
}
