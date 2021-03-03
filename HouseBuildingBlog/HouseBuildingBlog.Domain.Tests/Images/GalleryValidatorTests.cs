using FluentAssertions;
using HouseBuildingBlog.Domain.Images;
using HouseBuildingBlog.Domain.TestBase.Images;
using System;
using Xunit;

namespace HouseBuildingBlog.Domain.Tests.Images
{
	public class GalleryValidatorTests
	{
		private GalleryValidator SuT { get; }

		public GalleryValidatorTests()
		{
			SuT = new GalleryValidator();
		}

		[Fact]
		public void Given_GalleryWithTitle_Expect_ErrorsWithoutNoTitleError()
		{
			//Arrange
			var gallery = new TestGallery(Guid.NewGuid(), "Test");

			//Act
			var errors = SuT.Validate(gallery);

			//Assert
			errors.Should().NotContain(e => e.ErrorCode == GalleryErrorCodes.HasNoTitle);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("  ")]
		public void Given_GalleryWothEmptyTitle_Expect_NoTitleError(string title)
		{
			//Arrange
			var gallery = new TestGallery(Guid.NewGuid(), title);

			//Act
			var errors = SuT.Validate(gallery);

			//Assert
			errors.Should().Contain(e => e.ErrorCode == GalleryErrorCodes.HasNoTitle);
		}
	}
}
