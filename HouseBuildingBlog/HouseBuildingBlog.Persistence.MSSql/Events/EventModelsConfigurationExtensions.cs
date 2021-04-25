using Microsoft.EntityFrameworkCore;

namespace HouseBuildingBlog.Persistence.MSSql.Events
{
	public static class EventModelsConfigurationExtensions
	{
		public static void ConfigureEvents(this ModelBuilder modelBuilder)
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
		}
	}
}
