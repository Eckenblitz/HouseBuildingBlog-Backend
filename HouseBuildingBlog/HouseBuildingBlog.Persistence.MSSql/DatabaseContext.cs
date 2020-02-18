using HouseBuildingBlog.Persistence.MSSql.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseBuildingBlog.Persistence.MSSql
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Event> Events { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Document> Documents { get; set; }
		public DbSet<Image> Images { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(@"Server=.\HBB_SQLSERVER;Database=HouseBuildingBlog;Trusted_Connection=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Event>()
				.ToTable("Events")
				.HasKey(e => e.EventId);

			modelBuilder.Entity<Tag>()
				.ToTable("Tags")
				.HasKey(e => e.TagId);

			modelBuilder.Entity<Document>()
				.ToTable("Documents")
				.HasKey(e => e.DocumentId);

			modelBuilder.Entity<Image>()
				.ToTable("Images")
				.HasKey(e => e.ImageId);
		}
	}
}
