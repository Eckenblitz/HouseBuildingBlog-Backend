using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Events.Queries
{
	public class GetDocumentsHandler : IRequestHandler<GetDocumentsQuery, IActionResult>
	{
		public Task<IActionResult> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
