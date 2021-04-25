using HouseBuildingBlog.Domain.Files;
using HouseBuildingBlog.Domain.Images;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Images
{
	public class ImageFileModel : IImageFile
	{
		public Guid ImageId { get; set; }

		public FileType FileType { get; set; }

		public string FileName { get; set; }

		public byte[] Binaries { get; set; }

		public ImageModel Image { get; set; }
	}
}
