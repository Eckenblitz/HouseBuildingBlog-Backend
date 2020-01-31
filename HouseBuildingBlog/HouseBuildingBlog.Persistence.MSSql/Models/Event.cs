using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class Event
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Text { get; set; }

		public IList<Tag> Tags { get; set; }

		public IList<Document> Documents { get; set; }

		public IList<Image> Images { get; set; }
	}
}
