using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using HouseBuildingBlog.Api.Documents.Queries;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DocumentsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public DocumentsController(IMediator mediator)
		{
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		[HttpPost]
		[ProducesResponseType(typeof(DocumentQueryDto), StatusCodes.Status201Created)]
		public async Task<IActionResult> CreateDocument([FromBody] DocumentCommandDto dto)
		{
			return await _mediator.Send(new CreateDocumentCommand(dto));
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDocuments()
		{
			return await _mediator.Send(new GetAllDocumentsQuery());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSingleDocument(Guid id)
		{
			return await _mediator.Send(new GetSingleDocumentQuery(id));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] DocumentCommandDto dto)
		{
			return await _mediator.Send(new UpdateDocumentCommand(id, dto));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDocument(Guid id)
		{
			return await _mediator.Send(new DeleteDocumentCommand(id));

		}
	}
}
