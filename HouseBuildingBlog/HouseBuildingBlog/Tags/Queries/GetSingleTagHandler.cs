using HouseBuildingBlog.Tags.Queries.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Queries
{
    public class GetSingleTagHandler : IRequestHandler<GetSingleTagQuery, TagDto>
    {
        public Task<TagDto> Handle(GetSingleTagQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
