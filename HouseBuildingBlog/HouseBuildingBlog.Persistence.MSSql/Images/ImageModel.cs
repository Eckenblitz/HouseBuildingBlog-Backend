using HouseBuildingBlog.Domain.Images;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Images
{
	public class ImageModel : IImage
	{
		public Guid ImageId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public Guid GalleryId { get; set; }

		public ImageFileModel File { get; set; }
	}
}
