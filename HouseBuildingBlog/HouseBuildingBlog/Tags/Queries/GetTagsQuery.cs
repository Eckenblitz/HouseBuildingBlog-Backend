using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using System.Collections.Generic;

namespace HouseBuildingBlog.Tags.Queries
{
    public class GetTagsQuery : IRequest<IList<TagDto>>
    {
    }
}
