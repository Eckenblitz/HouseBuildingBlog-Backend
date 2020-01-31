using System;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class Tag
	{
		public Guid TagId { get; private set; }

		public string Title { get; private set; }
	}
}