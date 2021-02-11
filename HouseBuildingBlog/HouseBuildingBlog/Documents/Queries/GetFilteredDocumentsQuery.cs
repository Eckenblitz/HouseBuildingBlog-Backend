using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class GetFilteredDocumentsQuery : IRequest<IActionResult>
	{
		public IEnumerable<Guid> TagIds { get; }

		public GetFilteredDocumentsQuery(IEnumerable<Guid> tagIds)
		{
			TagIds = tagIds;
		}
	}
}
