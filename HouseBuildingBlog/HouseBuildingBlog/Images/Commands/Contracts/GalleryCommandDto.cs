using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Images.Commands.Contracts
{
	public class GalleryCommandDto
	{
		public string Title { get; set; }

		public IList<Guid> TagIds { get; set; }
	}
}
