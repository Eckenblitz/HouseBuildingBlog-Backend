using HouseBuildingBlog.Api.Costplan.Queries.Contracts;
using HouseBuildingBlog.Domain.Costplan;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Costplan.Commands
{
	public class DeleteCostplanItemHandler : IRequestHandler<DeleteCostplanItemCommand, IActionResult>
	{
		private readonly IWriteCostplanAggregate _writeCostplanAggregate;

		public DeleteCostplanItemHandler(IWriteCostplanAggregate writeCostplanAggregate)
		{
			_writeCostplanAggregate = writeCostplanAggregate;
		}

		public async Task<IActionResult> Handle(DeleteCostplanItemCommand request, CancellationToken cancellationToken)
		{
			var deletedItem = await _writeCostplanAggregate.DeleteCostplanItemAsync(request.CostplanItemId);

			if (deletedItem == null)
				return new NotFoundResult();

			return new OkObjectResult(new CostplanItemQueryDto(deletedItem));
		}
	}
}
