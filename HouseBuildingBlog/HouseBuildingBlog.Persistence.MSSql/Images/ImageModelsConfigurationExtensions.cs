using Microsoft.EntityFrameworkCore;

namespace HouseBuildingBlog.Persistence.MSSql.Images
{
	public static class ImageModelsConfigurationExtensions
	{
		public static void ConfigureImages(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<GalleryModel>(entity =>
			{
				entity.ToTable("Galleries", "Images");
				entity.HasKey(gallery => gallery.GalleryId);
				entity.Property(gallery => gallery.GalleryId).ValueGeneratedNever();
				entity.Property(gallery => gallery.Title).HasMaxLength(200).IsRequired();

				entity.HasOne(gallery => gallery.Event)
					.WithMany(@event => @event.Galleries)
					.HasForeignKey(gallery => gallery.EventId)
					.HasConstraintName("FK_Galleries_Events")
					.OnDelete(DeleteBehavior.SetNull);

				entity.Ignore(e => e.Images);
				entity.Ignore(e => e.Tags);
			});

			modelBuilder.Entity<AssignedGalleryTagModel>(entity =>
			{
				entity.ToTable("AssignedGalleryTags", "Images");
				entity.HasKey(et => new { et.GalleryId, et.TagId });

				entity.HasOne(et => et.Gallery)
					.WithMany(e => e.AssignedTags)
					.HasForeignKey(et => et.GalleryId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_AssignedGalleryTags_Galleries");

				entity.HasOne(et => et.Tag)
					.WithMany(t => t.AssignedGalleries)
					.HasForeignKey(et => et.TagId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_AssignedGalleryTags_Tags");
			});

			modelBuilder.Entity<ImageModel>(entity =>
			{
				entity.ToTable("Images", "Images");
				entity.HasKey(image => image.ImageId);

				entity.Property(image => image.Title).HasMaxLength(200);
				entity.Property(image => image.GalleryId).IsRequired();

				entity.HasOne(image => image.File)
					.WithOne(file => file.Image)
					.HasForeignKey<ImageFileModel>(file => file.ImageId);
			});

			modelBuilder.Entity<ImageFileModel>(entity =>
			{
				entity.ToTable("Files", "Images");
				entity.HasKey(file => file.ImageId);
				entity.Property(file => file.ImageId).ValueGeneratedNever();
				entity.Property(file => file.FileName).HasMaxLength(200).IsRequired();
				entity.Property(file => file.FileType)
					.HasConversion<string>()
					.HasMaxLength(20)
					.IsRequired();
				entity.Ignore(file => file.Binaries);
			});
		}
	}
}
