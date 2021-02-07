using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.TestBase.Documents;
using System;
using System.Collections.Generic;
using Xunit;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class DocumentValidatorTests
	{
		[Fact]
		public void Expect_ResultWithoutHasNoTitleError_When_TitleIsFilled()
		{
			//Arrange
			var document = new TestDocument(Guid.NewGuid(), new TestDocumentContent() { Title = "Test123" }, new List<Guid>());

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
			var document = new TestDocument(Guid.NewGuid(), new TestDocumentContent() { Title = title }, new List<Guid>());

			//Act
			var validationResult = DocumentValidator.Validate(document);

			//Assert
			var error = validationResult.Should().Contain(e => e.ErrorCode.Equals(DocumentErrorCodes.HasNoTitle)).Subject;
			error.ErrorParameters["DocumentId"].Should().Be(document.DocumentId.ToString());
		}
	}
}
