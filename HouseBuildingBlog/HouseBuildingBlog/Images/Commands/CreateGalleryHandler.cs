using AutoMapper;
using HouseBuildingBlog.Api.Images.Queries.Contracts;
using HouseBuildingBlog.Domain.Images;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Api.Images.Commands
{
	public class CreateGalleryHandler : IRequestHandler<CreateGalleryCommand, GalleryQueryDto>
	{
		private readonly IWriteImagesAggregate _writeImagesAggregate;
		private readonly IMapper _mapper;

		public CreateGalleryHandler(IWriteImagesAggregate writeImagesAggregate, IMapper mapper)
		{
			_writeImagesAggregate = writeImagesAggregate;
			_mapper = mapper;
		}

		public async Task<GalleryQueryDto> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
		{
			var gallery = await _writeImagesAggregate.CreateGalleryAsync(request.Title, request.TagIds, cancellationToken);
			return _mapper.Map<GalleryQueryDto>(gallery);
		}
	}
}
