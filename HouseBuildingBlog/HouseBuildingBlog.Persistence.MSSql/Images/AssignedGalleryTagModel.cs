using HouseBuildingBlog.Persistence.MSSql.Tags;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Images
{
	public class AssignedGalleryTagModel
	{
		public Guid GalleryId { get; set; }

		public Guid TagId { get; set; }

		public GalleryModel Gallery { get; set; }

		public TagModel Tag { get; set; }
	}
}
