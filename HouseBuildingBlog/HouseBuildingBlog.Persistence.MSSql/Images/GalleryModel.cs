using HouseBuildingBlog.Domain.Images;
using HouseBuildingBlog.Domain.Tags;
using HouseBuildingBlog.Persistence.MSSql.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Persistence.MSSql.Images
{
	public class GalleryModel : IGallery
	{
		public Guid GalleryId { get; set; }

		public string Title { get; set; }

		public IEnumerable<IImage> Images => AssignedImages;

		public IEnumerable<ITag> Tags => AssignedTags?.Select(at => at.Tag);

		public Guid? EventId { get; set; }

		public ICollection<ImageModel> AssignedImages { get; set; }

		public ICollection<AssignedGalleryTagModel> AssignedTags { get; set; }

		public EventModel Event { get; set; }
	}
}
