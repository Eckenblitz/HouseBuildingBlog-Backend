using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using System;
using Xunit;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class DocumentValidatorTests
	{
		[Fact]
		public void Expect_NoHasNoTitleError_When_TitleIsFilled()
		{
			//Arrange
			var document = new Document(Guid.NewGuid(), new TestDocumentContent() { Title = "Test123" });

			//Act
			var validationResult = DocumentValidator.Validate(document);

			//Assert
			validationResult.Should().NotContain(e => e.ErrorCode.Equals(DocumentErrorCodes.HasNoTitle));
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("  ")]
		public void Expect_HasNoTitleError_When_TitleIsEmpty(string? title)
		{
			//Arrange
			var document = new Document(Guid.NewGuid(), new TestDocumentContent() { Title = title });

			//Act
			var validationResult = DocumentValidator.Validate(document);

			//Assert
			var error = validationResult.Should().Contain(e => e.ErrorCode.Equals(DocumentErrorCodes.HasNoTitle)).Subject;
			error.ErrorParameters["DocumentId"].Should().Be(document.DocumentId.ToString());
		}
	}
}
