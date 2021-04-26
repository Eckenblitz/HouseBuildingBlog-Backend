using AutoMapper;
using HouseBuildingBlog.Api.Tags.Queries.Contracts;
using HouseBuildingBlog.Domain.Tags;

namespace HouseBuildingBlog.Api.Tags
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<ITag, TagQueryDto>();
        }
    }
}
