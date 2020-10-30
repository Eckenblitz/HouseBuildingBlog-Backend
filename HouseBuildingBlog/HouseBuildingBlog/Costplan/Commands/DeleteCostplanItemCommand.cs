using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Costplan.Commands
{
	public class DeleteCostplanItemCommand : IRequest<IActionResult>
	{
		public Guid CostplanItemId { get; }

		public DeleteCostplanItemCommand(Guid costplanItemId)
		{
			CostplanItemId = costplanItemId;
		}
	}
}
