using HouseBuildingBlog.Persistence.MSSql.Documents;
using HouseBuildingBlog.Persistence.MSSql.Events;
using HouseBuildingBlog.Persistence.MSSql.Tags;
using Microsoft.EntityFrameworkCore;

namespace HouseBuildingBlog.Persistence.MSSql
{
	public class DatabaseContext : DbContext
	{
		public DbSet<EventModel> Events { get; set; }
		public DbSet<TagModel> Tags { get; set; }
		public DbSet<AssignedTagsModel> AssignedEventTags { get; set; }

		public DbSet<DocumentModel> Documents { get; set; }
		public DbSet<DocumentFileModel> DocumentFiles { get; set; }

		private MSSQLConfig _config;

		public DatabaseContext(DbContextOptions<DatabaseContext> options, MSSQLConfig config) : base(options)
		{
			_config = config;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer($"Server={_config.Server};Database={_config.DatabaseName};Trusted_Connection={_config.TrustedConnection}");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EventModel>(e =>
			{
				e.ToTable("Events", "Events");
				e.HasKey(e => e.EventId);
				e.Ignore(e => e.TagIds);
				e.Property(e => e.EventId).ValueGeneratedNever();
				e.Property(e => e.Title).IsRequired();
			});

			modelBuilder.Entity<AssignedTagsModel>(e =>
			{
				e.ToTable("AssignedTags", "Events");
				e.HasKey(et => new { et.EventId, et.TagId });

				e.HasOne(et => et.Event)
					.WithMany(e => e.AssignedTags)
					.HasForeignKey(et => et.EventId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_AssignedTags_Events");

				e.HasOne(et => et.Tag)
					.WithMany(t => t.AssignedEvents)
					.HasForeignKey(et => et.TagId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_AssignedTags_Tags");
			});

			modelBuilder.Entity<TagModel>(entity =>
			{
				entity.ToTable("Tags", "Events");
				entity.HasKey(e => e.TagId);

				entity.Property(e => e.TagId).ValueGeneratedNever();
				entity.Property(e => e.Title)
					.IsRequired()
					.HasMaxLength(200);
			});

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
		}
	}
}
