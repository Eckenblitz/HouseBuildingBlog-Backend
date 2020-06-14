using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Events.Queries
{
	public class GetFilteredEventsQuery : IRequest<IActionResult>
	{
		public IList<Guid> TagIds { get; }

		public GetFilteredEventsQuery(IList<Guid> tagIds)
		{
			TagIds = tagIds;
		}
	}
}
