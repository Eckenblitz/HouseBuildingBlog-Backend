using HouseBuildingBlog.Domain.Tags;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IGallery
	{
		Guid GalleryId { get; }

		string Title { get; }

		IEnumerable<IImage> Images { get; }

		IEnumerable<ITag> Tags { get; }

		Guid? EventId { get; }
	}
}
