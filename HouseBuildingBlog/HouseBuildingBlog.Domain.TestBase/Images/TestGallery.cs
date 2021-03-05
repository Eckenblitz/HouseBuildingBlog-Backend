using HouseBuildingBlog.Domain.Images;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.TestBase.Images
{
	public class TestGallery : IGallery
	{
		public Guid GalleryId { get; set; }

		public string Title { get; set; }

		public IEnumerable<Guid> ImageIds { get; set; }

		public IEnumerable<Guid> TagIds { get; set; }

		public TestGallery() { }

		public TestGallery(Guid galleryId, string title)
		{
			GalleryId = galleryId;
			Title = title;
			ImageIds = new List<Guid>();
			TagIds = new List<Guid>();
		}
	}
}
