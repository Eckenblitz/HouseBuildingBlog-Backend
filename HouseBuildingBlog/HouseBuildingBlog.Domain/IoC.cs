using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Images;
using HouseBuildingBlog.Domain.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBuildingBlog.Domain
{
	public static class IoC
	{
		public static void RegisterDomainDependencies(this IServiceCollection services)
		{
			//Documents
			services.AddTransient<IWriteDocumentsAggregate, WriteDocumentsAggregate>();
			services.AddTransient<IReadDocumentsAggregate, ReadDocumentsAggregate>();

			//Images
			services.AddTransient<IDomainValidator<IGallery>, GalleryValidator>();
		}
	}
}
