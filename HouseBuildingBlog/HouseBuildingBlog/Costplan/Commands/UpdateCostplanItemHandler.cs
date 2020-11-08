using HouseBuildingBlog.Api.Costplan.Models;
using HouseBuildingBlog.Api.Costplan.Queries.Contracts;
using HouseBuildingBlog.Domain.Costplan;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Costplan.Commands
{
	public class UpdateCostplanItemHandler : IRequestHandler<UpdateCostplanItemCommand, IActionResult>
	{
		private readonly IWriteCostplanAggregate _writeCostplanAggregate;

		public UpdateCostplanItemHandler(IWriteCostplanAggregate writeCostplanAggregate)
		{
			_writeCostplanAggregate = writeCostplanAggregate;
		}

		public async Task<IActionResult> Handle(UpdateCostplanItemCommand request, CancellationToken cancellationToken)
		{
			var item = new CostplanItem(request.CostplanItemId, request.Data);

			var updatedItems = await _writeCostplanAggregate.UpdateCostplanItemAsync(item);

			if (updatedItems == null || updatedItems.Count() == 0)
				return new NotFoundResult();

			return new OkObjectResult(updatedItems.Select(i => new CostplanItemQueryDto(i)));
		}
	}
}
