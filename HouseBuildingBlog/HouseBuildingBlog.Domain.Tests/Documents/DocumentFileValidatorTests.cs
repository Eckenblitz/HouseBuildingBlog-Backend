using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Files;
using HouseBuildingBlog.Domain.TestBase.Documents;
using Xunit;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class DocumentFileValidatorTests
	{
		[Theory]
		[InlineData(FileType.PDF)]
		[InlineData(FileType.TXT)]
		public void Expect_NoFileTypeNotAllowedError_When_ValidFileTypeIsUsed(FileType fileType)
		{
			//Arrange
			var documentFile = new TestDocumentFile() { FileType = fileType };

			//Act
			var validationResult = DocumentFileValidator.Validate(documentFile);

			//Assert
			validationResult.Should().NotContain(e => e.ErrorCode.Equals(DocumentErrorCodes.FileTypeNotAllowed));
		}

		[Theory]
		[InlineData(FileType.PNG)]
		[InlineData(FileType.JPG)]
		public void Expect_TypeNotAllowedError_When_InvalidFileTypeIsUsed(FileType fileType)
		{
			//Arrange
			var documentFile = new TestDocumentFile() { FileType = fileType };

			//Act
			var validationResult = DocumentFileValidator.Validate(documentFile);

			//Assert
			var error = validationResult.Should().Contain(e => e.ErrorCode.Equals(DocumentErrorCodes.FileTypeNotAllowed)).Subject;
			error.ErrorParameters["DocumentId"].Should().Be(documentFile.DocumentId.ToString());
		}
	}
}
