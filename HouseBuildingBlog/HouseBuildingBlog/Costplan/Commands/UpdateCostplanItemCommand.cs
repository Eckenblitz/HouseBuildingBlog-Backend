using HouseBuildingBlog.Api.Costplan.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Api.Costplan.Commands
{
	public class UpdateCostplanItemCommand : IRequest<IActionResult>
	{
		public Guid CostplanItemId { get; }

		public CostplanItemCommandDto Data { get; }

		public UpdateCostplanItemCommand(Guid costplanItemId, CostplanItemCommandDto data)
		{
			CostplanItemId = costplanItemId;
			Data = data;
		}
	}
}
