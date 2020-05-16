using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Events.Commands.Contracts
{
	public class EventCommandDto
	{
		public string Title { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public IList<Guid> TagIds { get; set; }
	}
}
