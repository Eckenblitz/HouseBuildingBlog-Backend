using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using System;

namespace HouseBuildingBlog.Tags.Queries
{
    public class GetSingleTagQuery : IRequest<TagDto>
    {
        public Guid TagId { get; }

        public GetSingleTagQuery(Guid tagId)
        {
            TagId = tagId;
        }
    }
}
