using AutoMapper;
using HouseBuildingBlog.Api.Events.Queries.Contracts;
using HouseBuildingBlog.Domain.Events;

namespace HouseBuildingBlog.Api.Events
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<IEvent, SimpleEventQueryDto>();
        }
    }
}
