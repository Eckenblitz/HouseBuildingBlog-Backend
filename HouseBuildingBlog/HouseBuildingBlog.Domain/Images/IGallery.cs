﻿using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IGallery
	{
		Guid GalleryId { get; }

		string Title { get; }

		IEnumerable<IImage> Images { get; }

		IEnumerable<Guid> TagIds { get; }
	}
}