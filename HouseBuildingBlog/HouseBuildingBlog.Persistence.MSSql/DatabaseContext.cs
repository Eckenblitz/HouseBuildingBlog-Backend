using HouseBuildingBlog.Persistence.MSSql.Documents;
using HouseBuildingBlog.Persistence.MSSql.Events;
using HouseBuildingBlog.Persistence.MSSql.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HouseBuildingBlog.Persistence.MSSql
{
	public class DatabaseContext : DbContext
	{
		public DbSet<EventModel> Events { get; set; }
		public DbSet<TagModel> Tags { get; set; }
		public DbSet<AssignedEventTagModel> AssignedEventTags { get; set; }

		public DbSet<DocumentModel> Documents { get; set; }
		public DbSet<DocumentFileModel> DocumentFiles { get; set; }
		public DbSet<AssignedDocumentTagModel> AssignedDocumentTags { get; set; }

		private MSSQLConfig _config;
		private ILogger<DatabaseContext> _logger;

		public DatabaseContext(DbContextOptions<DatabaseContext> options, MSSQLConfig config, ILogger<DatabaseContext> logger) : base(options)
		{
			_logger = logger;
			_config = config;

			_logger.LogInformation(_config.ToString());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var server = $"{_config.Server}" + (_config.Port.HasValue ? $",{_config.Port.Value}" : string.Empty);
				var credentials = !_config.TrustedConnection ? $";user id={_config.UserId};pwd={_config.UserPw}" : string.Empty;
				var connectionString =
					$"Server={server};Database={_config.DatabaseName};Trusted_Connection={_config.TrustedConnection}{credentials}";
				_logger.LogInformation($"SQL ConnectionString: {connectionString}");
				optionsBuilder.UseSqlServer(connectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EventModel>(e =>
			{
				e.ToTable("Events", "Events");
				e.HasKey(e => e.EventId);
				e.Ignore(e => e.TagIds);
				e.Ignore(e => e.DocumentIds);
				e.Property(e => e.EventId).ValueGeneratedNever();
				e.Property(e => e.Title).IsRequired();
			});

			modelBuilder.Entity<AssignedEventTagModel>(e =>
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
				entity.ToTable("Tags", "Tags");
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
