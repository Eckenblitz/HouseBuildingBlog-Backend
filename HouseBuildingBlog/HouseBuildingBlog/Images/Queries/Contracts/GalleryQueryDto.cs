using HouseBuildingBlog.Api.Events.Queries.Contracts;
using HouseBuildingBlog.Api.Tags.Queries.Contracts;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Images.Queries.Contracts
{
    public class GalleryQueryDto
    {
        public Guid GalleryId { get; set; }

        public string Title { get; set; }

        public IEnumerable<ImageQueryDto> Images { get; set; }

        public SimpleEventQueryDto Event { get; set; }

        public IEnumerable<TagQueryDto> Tags { get; set; }
    }
}
