using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Tags.Queries
{
	public class GetSingleTagQuery : IRequest<IActionResult>
	{
		public Guid TagId { get; }

		public GetSingleTagQuery(Guid tagId)
		{
			TagId = tagId;
		}
	}
}
