using HouseBuildingBlog.Api.Filter;
using HouseBuildingBlog.Domain.Errors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[DomainExceptionFilter]
	public class ImagesController : ControllerBase
	{
		[HttpPost("Gallery")]
		public async Task<IActionResult> CreateGallery()
		{
			throw new AggregateNotFoundException("TEST", Guid.Empty);
		}

		[HttpGet("Gallery/{galleryId}")]
		public async Task<IActionResult> GetGallery(Guid galleryId)
		{
			throw new NotImplementedException();
		}

		[HttpPatch("Gallery/{galleryId}")]
		public async Task<IActionResult> UpdateGallery(Guid galleryId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("Gallery/{galleryId}")]
		public async Task<IActionResult> DeleteGallery(Guid galleryId)
		{
			throw new NotImplementedException();
		}

		[HttpPost("Gallery/{galleryId}/Image")]
		public async Task<IActionResult> UploadImage(Guid galleryId)
		{
			throw new NotImplementedException();
		}

		[HttpPost("Gallery/{galleryId}/Image/{imageId}")]
		public async Task<IActionResult> DownloadImage(Guid galleryId, Guid imageId)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("Gallery/{galleryId}/Image/{imageId}")]
		public async Task<IActionResult> DeleteImage(Guid galleryId, Guid imageId)
		{
			throw new NotImplementedException();
		}
	}
}
