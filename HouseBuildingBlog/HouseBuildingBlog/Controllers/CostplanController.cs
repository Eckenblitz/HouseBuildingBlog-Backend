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

		[HttpPost("Categories")]
		public async Task<IActionResult> CreateCategory()
		{
			throw new NotImplementedException();
		}

		[HttpPatch("Categories/{id}")]
		public async Task<IActionResult> UpdateCategory(Guid id)
		{
			throw new NotImplementedException();
		}

		[HttpPatch("Categories/{id}/Position")]
		public async Task<IActionResult> MoveCategory(Guid id)
		{
			throw new NotImplementedException();
		}

		[HttpPut("Categories/{id}/Documents/{documentId}")]
		public async Task<IActionResult> AssignDocument(Guid id, Guid documentId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("Categories/{id}/Documents/{documentId}")]
		public async Task<IActionResult> RemoveDocumen(Guid id, Guid documentId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("Categories/{id}")]
		public async Task<IActionResult> DeleteCategory(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
