using AutoMapper;
using HouseBuildingBlog.Api.Images.Queries.Contracts;
using HouseBuildingBlog.Domain.Images;

namespace HouseBuildingBlog.Api.Images
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<IGallery, GalleryQueryDto>();
            CreateMap<IImage, ImageQueryDto>();
        }
    }
}
