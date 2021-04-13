using HouseBuildingBlog.Domain.Files;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IWriteImagesAggregate
	{
		Task<IGallery> CreateGalleryAsync(IGallery gallery, CancellationToken cancellationToken);

		Task<IGallery> UpdateGalleryAsync(IGallery gallery, CancellationToken cancellationToken);

		Task<IGallery> DeleteGalleryAsync(Guid galleryId, CancellationToken cancellationToken);


		Task<IImage> CreateImageAsync(IImage image, CancellationToken cancellationToken);

		Task<IImage> UpdateImageAsync(IImage image, CancellationToken cancellationToken);

		Task<IImage> UploadImageAsync(Guid imageId, IFile file, CancellationToken cancellationToken);

		Task<IImage> AssignImageToGalleryAsync(Guid imageId, Guid galleryId, CancellationToken cancellationToken);

		Task<IImage> RemoveFromGalleryAsync(Guid imageId, CancellationToken cancellationToken);

		Task<IImage> DeleteImageAsync(Guid imageId, CancellationToken cancellationToken);
	}
}
