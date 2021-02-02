using FluentAssertions;
using HouseBuildingBlog.Api.Services;
using HouseBuildingBlog.Domain.Files;
using HouseBuildingBlog.Domain.TestBase;
using HouseBuildingBlog.Domain.TestBase.Files;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Services
{
	public class FileResponseServiceTests
	{
		private FileResponseService SuT { get; }

		public FileResponseServiceTests()
		{
			SuT = new FileResponseService();
		}

		[Theory]
		[InlineData(FileType.JPG, "image/jpeg")]
		[InlineData(FileType.PNG, "image/png")]
		[InlineData(FileType.TXT, "text/plain")]
		[InlineData(FileType.PDF, "application/pdf")]
		public void Expect_RightMediaType_When_FileIsConverted(FileType fileType, string mediaType)
		{
			//Arrange
			var file = new TestFile()
			{
				FileName = "Test",
				FileType = fileType,
				Binaries = TestDataCreator.CreateRandomBytes()
			};

			//Act
			var result = SuT.CreateFileContentResult(file);

			//Assert
			result.ContentType.Should().Be(mediaType);
			result.FileContents.Should().BeEquivalentTo(file.Binaries);
		}
	}
}
