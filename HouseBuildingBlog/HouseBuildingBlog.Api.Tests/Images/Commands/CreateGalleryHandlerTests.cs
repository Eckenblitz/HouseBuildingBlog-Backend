using AutoMapper;
using FluentAssertions;
using HouseBuildingBlog.Api.Images.Commands;
using HouseBuildingBlog.Api.Images.Queries.Contracts;
using HouseBuildingBlog.Domain.Images;
using HouseBuildingBlog.Domain.TestBase.Images;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Images.Commands
{
	public class CreateGalleryHandlerTests
	{
		private CreateGalleryHandler SuT { get; }
		private readonly IWriteImagesAggregate _writeImagesAggregate;
		private readonly IMapper _mapper;

		public CreateGalleryHandlerTests()
		{
			_writeImagesAggregate = Substitute.For<IWriteImagesAggregate>();
			_mapper = Substitute.For<IMapper>();
			SuT = new CreateGalleryHandler(_writeImagesAggregate, _mapper);
		}

		[Fact]
		public async Task WriteAggregate_Received_CreateGalleryAsync()
		{
			//Arrange
			var title = "galleryTest";
			var tagIds = new List<Guid>();

			//Act
			_ = await SuT.Handle(new CreateGalleryCommand(title, tagIds), CancellationToken.None);

			//Assert
			_ = _writeImagesAggregate.Received(1).CreateGalleryAsync(Arg.Is(title), Arg.Is(tagIds), Arg.Any<CancellationToken>());
		}

		[Fact]
		public async Task Mapper_Received_Result_From_Aggregate()
		{
			//Arrange
			var title = "galleryTest";
			var tagIds = new List<Guid>();
			var gallery = new TestGallery();
			_writeImagesAggregate.CreateGalleryAsync(Arg.Is(title), Arg.Is(tagIds), Arg.Any<CancellationToken>()).Returns(gallery);

			//Act
			_ = await SuT.Handle(new CreateGalleryCommand(title, tagIds), CancellationToken.None);

			//Assert
			_ = _mapper.Received(1).Map<GalleryQueryDto>(Arg.Is(gallery));
		}

		[Fact]
		public async Task Returns_Dto()
		{
			//Arrange
			var title = "galleryTest";
			var tagIds = new List<Guid>();
			var dto = new GalleryQueryDto();
			_mapper.Map<GalleryQueryDto>(Arg.Any<object>()).Returns(dto);

			//Act
			var result = await SuT.Handle(new CreateGalleryCommand(title, tagIds), CancellationToken.None);

			//Assert
			result.Should().Be(dto);
		}
	}
}
