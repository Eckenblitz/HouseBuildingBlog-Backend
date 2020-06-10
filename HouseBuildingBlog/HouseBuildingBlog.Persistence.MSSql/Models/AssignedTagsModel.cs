using System;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class AssignedTagsModel
	{
		public Guid EventId { get; set; }

		public EventModel Event { get; set; }

		public Guid TagId { get; set; }

		public TagModel Tag { get; set; }
	}
}
