using HouseBuildingBlog.Documents.Commands;
using HouseBuildingBlog.Documents.Queries;
using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentsController : ControllerBase
	{
		private readonly ILogger<DocumentsController> _logger;
		private readonly IMediator _mediator;

		public DocumentsController(ILogger<DocumentsController> logger, IMediator mediator)
		{
			_logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
			_mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
		}

		[HttpPost]
		public async Task<IActionResult> CreateDocument([FromBody]Documents.Commands.Contracts.DocumentDto dto)
		{
			return await _mediator.Send(new CreateDocumentCommand(dto));
		}

		[HttpGet("{id}")]
		public async Task<Documents.Queries.Contracts.DocumentDto> GetSingleDocument(Guid id)
		{
			return await _mediator.Send(new GetSingleDocumentQuery(id));
		}

		[HttpGet("{id}/File")]
		public async Task<Documents.Queries.Contracts.DocumentFileDto> GetDocumentFile(Guid id)
		{
			return await _mediator.Send(new GetDocumentFileQuery(id));
		}

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateDocument(Guid id, [FromBody]Documents.Commands.Contracts.DocumentDto dto)
		{
			return await _mediator.Send(new UpdateDocumentCommand(id, dto));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDocument(Guid id)
		{
			return await _mediator.Send(new DeleteDocumentCommand(id));
		}

		[HttpGet]
		public async Task<IList<Documents.Queries.Contracts.DocumentDto>> GetDocuments([FromBody]QueryDocumentsDto query)
		{
			return await _mediator.Send(new GetDocumentsQuery(query));
		}
	}
}