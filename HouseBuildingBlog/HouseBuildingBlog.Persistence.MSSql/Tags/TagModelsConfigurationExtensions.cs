using Microsoft.EntityFrameworkCore;

namespace HouseBuildingBlog.Persistence.MSSql.Tags
{
	public static class TagModelsConfigurationExtensions
	{
		public static void ConfigureTags(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TagModel>(entity =>
			{
				entity.ToTable("Tags", "Tags");
				entity.HasKey(e => e.TagId);

				entity.Property(e => e.TagId).ValueGeneratedNever();
				entity.Property(e => e.Title)
					.IsRequired()
					.HasMaxLength(200);
			});
		}
	}
}
