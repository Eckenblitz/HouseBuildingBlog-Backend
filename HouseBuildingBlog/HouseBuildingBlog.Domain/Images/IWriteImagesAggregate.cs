using HouseBuildingBlog.Domain.Files;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IWriteImagesAggregate
	{
		Task<IGallery> CreateGalleryAsync(string title, IEnumerable<Guid> tagIds, CancellationToken cancellationToken);

		Task<IGallery> UpdateGalleryAsync(IGallery gallery, CancellationToken cancellationToken);

		Task<IGallery> AssignEventAsync(Guid galleryId, Guid eventId, CancellationToken cancellationToken);

		Task<IGallery> UnassignEventAsync(Guid galleryId, CancellationToken cancellationToken);

		Task<IGallery> DeleteGalleryAsync(Guid galleryId, CancellationToken cancellationToken);


		Task<IImage> CreateImageAsync(IImage image, CancellationToken cancellationToken);

		Task<IImage> UpdateImageAsync(IImage image, CancellationToken cancellationToken);

		Task<IImage> UploadImageFileAsync(Guid imageId, IFile file, CancellationToken cancellationToken);

		Task<IImage> DeleteImageAsync(Guid imageId, CancellationToken cancellationToken);
	}
}
