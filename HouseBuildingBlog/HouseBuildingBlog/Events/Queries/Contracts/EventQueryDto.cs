﻿using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Events.Queries.Contracts
{
	public class EventQueryDto
	{
		public Guid EventId { get; set; }

		public string Title { get; set; }

		public DateTime Date { get; set; }

		public IList<Guid> Tags { get; set; }

		public string Description { get; set; }
	}
}
