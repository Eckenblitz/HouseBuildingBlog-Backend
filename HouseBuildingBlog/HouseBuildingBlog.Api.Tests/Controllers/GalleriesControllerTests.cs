using HouseBuildingBlog.Api.Controllers;
using HouseBuildingBlog.Api.Images.Commands;
using HouseBuildingBlog.Api.Images.Commands.Contracts;
using MediatR;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Controllers
{
	public class GalleriesControllerTests
	{
		private GalleriesController SuT { get; }
		private readonly IMediator _mediator;

		public GalleriesControllerTests()
		{
			_mediator = Substitute.For<IMediator>();
			SuT = new GalleriesController(_mediator);
		}

		[Fact]
		public async Task Given_CreateGallery_Expect_CreateGalleryCommand()
		{
			//Arrange
			var dto = new GalleryCommandDto()
			{
				Title = "galleryTest",
				TagIds = new List<Guid>() { Guid.NewGuid() }
			};

			//Act
			_ = await SuT.CreateGallery(dto, CancellationToken.None);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<CreateGalleryCommand>(c => c.Title == dto.Title && c.TagIds.SequenceEqual(dto.TagIds)),
				Arg.Any<CancellationToken>());
		}
	}
}
