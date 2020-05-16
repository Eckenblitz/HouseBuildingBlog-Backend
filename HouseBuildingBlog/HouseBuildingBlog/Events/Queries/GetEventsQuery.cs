using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetEventsQuery : IRequest<IActionResult>
	{
		public IList<Guid> TagIds { get; }

		public GetEventsQuery(IList<Guid> tagIds)
		{
			TagIds = tagIds;
		}
	}
}
