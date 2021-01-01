using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Events.Queries
{
	public class GetDocumentsHandler : IRequestHandler<GetDocumentsQuery, IActionResult>
	{
		private readonly IReadEventsAggregate _readEventsAggregate;

		public GetDocumentsHandler(IReadEventsAggregate readEventsAggregate)
		{
			_readEventsAggregate = readEventsAggregate;
		}

		public async Task<IActionResult> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var documents = await _readEventsAggregate.GetAssignedDocumentsAsync(request.EventId);
				return new OkObjectResult(documents.Select(d => new DocumentQueryDto(d)));
			}
			catch (AggregateNotFoundException ex)
			{
				return new NotFoundObjectResult(ex.Error);
			}
		}
	}
}
