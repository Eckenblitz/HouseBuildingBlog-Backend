using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Queries
{
    public class GetTagsHandler : IRequestHandler<GetTagsQuery, IList<TagDto>>
    {
        public Task<IList<TagDto>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
