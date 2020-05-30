using System;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class EventTags
	{
		public Guid EventId { get; set; }

		public EventDBModel Event { get; set; }

		public Guid TagId { get; set; }

		public TagDBModel Tag { get; set; }
	}
}
