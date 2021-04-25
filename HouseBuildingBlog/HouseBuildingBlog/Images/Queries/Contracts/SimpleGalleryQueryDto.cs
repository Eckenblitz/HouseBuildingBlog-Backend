using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Images.Queries.Contracts
{
	public class SimpleGalleryQueryDto
	{
		public Guid GalleryId { get; set; }

		public string Title { get; set; }

		public Guid? EventId { get; set; }

		IEnumerable<Guid> ImageIds { get; set; }
	}
}
