using HouseBuildingBlog.Api.Filter;
using HouseBuildingBlog.Api.Images.Commands;
using HouseBuildingBlog.Api.Images.Commands.Contracts;
using HouseBuildingBlog.Api.Images.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[DomainExceptionFilter]
	public class GalleriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public GalleriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<GalleryQueryDto> CreateGallery([FromBody] GalleryCommandDto dto, CancellationToken cancellationToken)
		{
			return await _mediator.Send(new CreateGalleryCommand(dto.Title, dto.TagIds), cancellationToken);
		}

		[HttpGet]
		public async Task<SimpleGalleryQueryDto[]> QueryGallieries(IEnumerable<Guid> tagIds)
		{
			throw new NotImplementedException();
		}

		[HttpGet("{galleryId}")]
		public async Task<GalleryQueryDto> GetGallery(Guid galleryId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpPatch("{galleryId}")]
		public async Task<GalleryQueryDto> UpdateGallery(Guid galleryId, [FromBody] GalleryCommandDto dto, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{galleryId}")]
		public async Task<GalleryQueryDto> DeleteGallery(Guid galleryId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpPatch("{galleryId}/Event")]
		public async Task<GalleryQueryDto> AssignEvent(Guid galleryId, Guid eventId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{galleryId}/Event")]
		public async Task<GalleryQueryDto> UnassignEvent(Guid galleryId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpPost("{galleryId}/Images")]
		public async Task<ImageQueryDto> UploadImage(Guid galleryId, [FromBody] ImageCommandDto dto, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpGet("{galleryId}/Images/{imageId}")]
		public async Task<FileContentResult> DownloadImage(Guid galleryId, Guid imageId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpPut("{galleryId}/Images/{imageId}")]
		public async Task<ImageQueryDto> UpdateImage(Guid galleryId, Guid imageId, [FromBody] ImageCommandDto dto, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{galleryId}/Images/{imageId}")]
		public async Task<ImageQueryDto> DeleteImage(Guid galleryId, Guid imageId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
