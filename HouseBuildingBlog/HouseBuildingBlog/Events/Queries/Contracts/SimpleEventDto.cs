using System;

namespace HouseBuildingBlog.Events.Queries.Contracts
{
	public class SimpleEventDto
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }
	}
}
