using HouseBuildingBlog.Api.Costplan.Commands;
using HouseBuildingBlog.Api.Costplan.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CostplanController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CostplanController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetCostplan()
		{
			throw new NotImplementedException();
		}

		[HttpPost("Items")]
		public async Task<IActionResult> CreateItem([FromBody] CostplanItemCommandDto commandDto)
		{
			return await _mediator.Send(new CreateCostplanItemCommand(commandDto));
		}

		[HttpPatch("Items/{id}")]
		public async Task<IActionResult> UpdateItem(Guid id, [FromBody] CostplanItemCommandDto commandDto)
		{
			return await _mediator.Send(new UpdateCostplanItemCommand(id, commandDto));
		}

		[HttpPut("Items/{id}/Documents/{documentId}")]
		public async Task<IActionResult> AssignDocument(Guid id, Guid documentId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("Items/{id}/Documents/{documentId}")]
		public async Task<IActionResult> RemoveDocument(Guid id, Guid documentId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("Items/{id}")]
		public async Task<IActionResult> DeleteItem(Guid id)
		{
			return await _mediator.Send(new DeleteCostplanItemCommand(id));
		}
	}
}
