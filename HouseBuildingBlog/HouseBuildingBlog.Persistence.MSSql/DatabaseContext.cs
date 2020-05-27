using HouseBuildingBlog.Persistence.MSSql.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseBuildingBlog.Persistence.MSSql
{
	public class DatabaseContext : DbContext
	{
		public DbSet<EventDBModel> Events { get; set; }
		public DbSet<TagDBModel> Tags { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			/*if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(@"Server=.\HBB_SQLSERVER;Database=HouseBuildingBlog;Trusted_Connection=True;");
			}*/
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EventDBModel>()
				.ToTable("Events", "Events")
				.HasKey(e => e.EventId);

			modelBuilder.Entity<TagDBModel>()
				.ToTable("Tags", "Events")
				.HasKey(e => e.TagId);
		}
	}
}
