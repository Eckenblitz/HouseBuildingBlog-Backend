using HouseBuildingBlog.Persistence.MSSql.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseBuildingBlog.Persistence.MSSql
{
	public class DatabaseContext : DbContext
	{
		public DbSet<EventDBModel> Events { get; set; }
		public DbSet<TagDBModel> Tags { get; set; }
		public DbSet<AssignedTags> AssignedEventTags { get; set; }

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
			modelBuilder.Entity<EventDBModel>(e =>
			{
				e.ToTable("Events", "Events");
				e.HasKey(e => e.EventId);

				e.Ignore(e => e.Tags);
				e.Property(e => e.EventId).ValueGeneratedNever();
				e.Property(e => e.Title).IsRequired();
			});

			modelBuilder.Entity<AssignedTags>(e =>
			{
				e.ToTable("AssignedTags", "Events");
				e.HasKey(et => new { et.EventId, et.TagId });

				e.HasOne(et => et.Event)
					.WithMany(e => e.EventTags)
					.HasForeignKey(et => et.EventId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_AssignedTags_Events");

				e.HasOne(et => et.Tag)
					.WithMany(t => t.AssignedEvents)
					.HasForeignKey(et => et.TagId)
					.OnDelete(DeleteBehavior.Cascade)
					.HasConstraintName("FK_AssignedTags_Tags");
			});

			modelBuilder.Entity<TagDBModel>(e =>
			{
				e.ToTable("Tags", "Events");
				e.HasKey(e => e.TagId);

				e.Property(e => e.TagId).ValueGeneratedNever();
				e.Property(e => e.Title)
					.IsRequired()
					.HasMaxLength(200);
			});
		}
	}
}
