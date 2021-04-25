using HouseBuildingBlog.Persistence.MSSql.Documents;
using HouseBuildingBlog.Persistence.MSSql.Events;
using HouseBuildingBlog.Persistence.MSSql.Images;
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

		public DbSet<GalleryModel> Galleries { get; set; }
		public DbSet<ImageModel> Images { get; set; }
		public DbSet<ImageFileModel> ImageFiles { get; set; }
		public DbSet<AssignedGalleryTagModel> AssignedGalleryTags { get; set; }

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
			modelBuilder.ConfigureEvents();
			modelBuilder.ConfigureTags();
			modelBuilder.ConfigureDocuments();
			modelBuilder.ConfigureImages();
		}
	}
}
