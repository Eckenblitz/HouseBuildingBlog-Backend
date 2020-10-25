using HouseBuildingBlog.Api.Costplan.Models;
using HouseBuildingBlog.Api.Costplan.Queries.Contracts;
using HouseBuildingBlog.Domain.Costplan;
using HouseBuildingBlog.Domain.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Costplan.Commands
{
    public class CreateCostplanItemHandler : IRequestHandler<CreateCostplanItemCommand, IActionResult>
    {
        private readonly IWriteCostplanAggregate _writeCostplanAggregate;

        public CreateCostplanItemHandler(IWriteCostplanAggregate writeCostplanAggregate)
        {
            _writeCostplanAggregate = writeCostplanAggregate;
        }

        public async Task<IActionResult> Handle(CreateCostplanItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = new CostplanItem(Guid.NewGuid(), request.Data);
                var newItem = await _writeCostplanAggregate.CreateCostplanItemAsync(item);

                return new CreatedResult(string.Empty, new CostplanItemQueryDto(newItem));
            }
            catch (ValidationException)
            {
                return new BadRequestResult();
            }
        }
    }
}
