using Microsoft.EntityFrameworkCore;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public static class DocumentModelsConfigurationExtensions
	{
		public static void ConfigureDocuments(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DocumentModel>(entity =>
			{
				entity.ToTable("Documents", "Documents");
				entity.HasKey(e => e.DocumentId);
				entity.Property(e => e.DocumentId).ValueGeneratedNever();
				entity.Property(e => e.Title).IsRequired();
				entity.HasOne(et => et.Event)
					.WithMany(a => a.Documents)
					.HasForeignKey(a => a.EventId)
					.HasConstraintName("FK_Documents_Events")
					.OnDelete(DeleteBehavior.SetNull);
				entity.HasOne(e => e.File)
					.WithOne(df => df.Document)
					.HasForeignKey<DocumentFileModel>(e => e.DocumentId);
			});

			modelBuilder.Entity<DocumentFileModel>(entity =>
			{
				entity.ToTable("Files", "Documents");
				entity.HasKey(e => e.DocumentId);
				entity.Property(e => e.DocumentId).ValueGeneratedNever();
				entity.Property(e => e.FileName).HasMaxLength(200).IsRequired();
				entity.Property(e => e.FileType)
					.HasConversion<string>()
					.HasMaxLength(20)
					.IsRequired();
				entity.Ignore(e => e.Binaries);
			});

			modelBuilder.Entity<AssignedDocumentTagModel>(e =>
			{
				e.ToTable("AssignedTags", "Documents");
				e.HasKey(et => new { et.DocumentId, et.TagId });

				e.HasOne(et => et.Document)
					.WithMany(e => e.AssignedTags)
					.HasForeignKey(et => et.DocumentId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_AssignedTags_Documents");

				e.HasOne(et => et.Tag)
					.WithMany(t => t.AssignedDocuments)
					.HasForeignKey(et => et.TagId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_AssignedTags_Tags");
			});
		}
	}
}
