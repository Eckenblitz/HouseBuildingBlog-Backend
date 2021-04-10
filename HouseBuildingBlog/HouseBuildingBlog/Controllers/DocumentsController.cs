using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using HouseBuildingBlog.Api.Documents.Queries;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
		[ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateDocument([FromBody] DocumentCommandDto dto)
		{
			return await _mediator.Send(new CreateDocumentCommand(dto));
		}

		//ToDo: think of GET URL parameter max length
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<DocumentQueryDto>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetDocuments([FromQuery] IList<Guid> tagIds)
		{
			if (tagIds.Count > 0)
				return await _mediator.Send(new GetFilteredDocumentsQuery(tagIds));
			else
				return await _mediator.Send(new GetAllDocumentsQuery());
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(DocumentQueryDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetSingleDocument(Guid id)
		{
			return await _mediator.Send(new GetSingleDocumentQuery(id));
		}

		[HttpPut("{id}")]
		[ProducesResponseType(typeof(DocumentQueryDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdateDocument(Guid id, [FromBody] DocumentCommandDto dto)
		{
			return await _mediator.Send(new UpdateDocumentCommand(id, dto));
		}

		[HttpPatch("{id}/Event")]
		public async Task<IActionResult> AssignEventToDocument(Guid id, Guid eventId)
		{
			return await _mediator.Send(new AssignEventToDocumentCommand(id, eventId));
		}

		[HttpDelete("{id}/Event")]
		public async Task<IActionResult> UnassignEventFromDocument(Guid id)
		{
			return await _mediator.Send(new UnassignEventFromDocumentCommand(id));
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(typeof(DocumentQueryDto), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteDocument(Guid id)
		{
			return await _mediator.Send(new DeleteDocumentCommand(id));
		}

		[HttpPut("{id}/File")]
		public async Task<IActionResult> UploadFile(Guid id, IFormFile file)
		{
			return await _mediator.Send(new UploadDocumentFileCommand(id, file));
		}

		[HttpGet("{id}/File")]
		public async Task<IActionResult> DownloadFile(Guid id)
		{
			return await _mediator.Send(new DownloadDocumentFileQuery(id));
		}
	}
}
