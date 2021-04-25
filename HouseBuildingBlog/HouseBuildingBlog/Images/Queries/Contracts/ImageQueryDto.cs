using System;

namespace HouseBuildingBlog.Api.Images.Queries.Contracts
{
	public class ImageQueryDto
	{
		public Guid ImageId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public string FileName { get; set; }
	}
}
