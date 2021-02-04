using FluentAssertions;
using HouseBuildingBlog.Api.Services;
using HouseBuildingBlog.Domain.Files;
using HouseBuildingBlog.Domain.TestBase;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Services
{
	public class TransformFileServiceTests
	{
		private TransformFileService SuT { get; }

		public TransformFileServiceTests()
		{
			SuT = new TransformFileService();
		}

		[Theory]
		[InlineData(".jpg", FileType.JPG)]
		[InlineData(".png", FileType.PNG)]
		[InlineData(".pdf", FileType.PDF)]
		[InlineData(".txt", FileType.TXT)]
		public async Task Expect_RightFileType_When_FileIsTransformed(string fileExtension, FileType expectedFileType)
		{
			//Arrange
			var bytes = TestDataCreator.CreateRandomBytes();
			var fileName = "test" + fileExtension;
			IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "data", fileName);

			//Act
			var result = await SuT.TransformAsync(file);

			//Assert
			result.FileName.Should().Be(fileName);
			result.FileType.Should().Be(expectedFileType);
			result.Binaries.Should().BeEquivalentTo(bytes);
		}

		[Fact]
		public async Task Expect_NotSupportedException_When_FileExtensionIsNotSupported()
		{
			//Arrange
			var bytes = TestDataCreator.CreateRandomBytes();
			var fileName = "test.123";
			IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "data", fileName);

			//Act / Assert
			Func<Task<IFile>> action = async () => await SuT.TransformAsync(file);
			await action.Should().ThrowAsync<NotSupportedException>();
		}

		[Fact]
		public async Task Expect_InvalidOperationException_When_FileIsEmpty()
		{
			//Arrange
			var bytes = new byte[0];
			var fileName = "test.123";
			IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "data", fileName);

			//Act / Assert
			Func<Task<IFile>> action = async () => await SuT.TransformAsync(file);
			await action.Should().ThrowAsync<InvalidOperationException>();
		}

	}
}
