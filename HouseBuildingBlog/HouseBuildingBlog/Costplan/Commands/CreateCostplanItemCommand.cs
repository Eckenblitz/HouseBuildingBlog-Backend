using HouseBuildingBlog.Api.Costplan.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Api.Costplan.Commands
{
    public class CreateCostplanItemCommand : IRequest<IActionResult>
    {
        public CostplanItemCommandDto Data { get; }

        public CreateCostplanItemCommand(CostplanItemCommandDto data)
        {
            Data = data;
        }
    }
}
