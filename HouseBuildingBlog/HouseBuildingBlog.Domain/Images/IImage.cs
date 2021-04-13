using System;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IImage
	{
		Guid ImageId { get; }

		string Title { get; }

		string Comment { get; }

		Guid GalleryId { get; }
	}
}
