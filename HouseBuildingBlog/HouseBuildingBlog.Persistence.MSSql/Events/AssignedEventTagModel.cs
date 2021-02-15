using HouseBuildingBlog.Persistence.MSSql.Tags;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Events
{
	public class AssignedEventTagModel
	{
		public Guid EventId { get; set; }

		public EventModel Event { get; set; }

		public Guid TagId { get; set; }

		public TagModel Tag { get; set; }
	}
}
