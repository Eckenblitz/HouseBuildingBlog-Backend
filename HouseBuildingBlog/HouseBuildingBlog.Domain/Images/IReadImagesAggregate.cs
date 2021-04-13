using HouseBuildingBlog.Domain.Files;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IReadImagesAggregate
	{
		Task<IGallery> GetGalleryByIdAsync(Guid galleryId, CancellationToken cancellationToken);

		Task<IImage> GetImageAsync(Guid imageId, CancellationToken cancellationToken);

		Task<IFile> DownloadImageAsync(Guid imageId, CancellationToken cancellationToken);
	}
}
