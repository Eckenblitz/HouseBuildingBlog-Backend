using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.TestBase.Documents;
using System;
using System.Collections.Generic;
using Xunit;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class DocumentTests
	{
		[Fact]
		public void Expect_FilledProperties_When_IsCreated()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var content = new TestDocumentContent()
			{
				Title = "TestTitle",
				Comment = "TestComment",
				Price = 1.23M,
				EventId = Guid.NewGuid()
			};
			var tagIds = new List<Guid>() { Guid.NewGuid() };

			//Act
			var newDocument = new Document(documentId, content, tagIds);

			//Assert
			newDocument.DocumentId.Should().Be(documentId);
			newDocument.Title.Should().Be(content.Title);
			newDocument.Comment.Should().Be(content.Comment);
			newDocument.Price.Should().Be(content.Price);
			newDocument.EventId.Should().Be(content.EventId);
			newDocument.TagIds.Should().BeEquivalentTo(tagIds);
		}

		[Fact]
		public void Expect_UpdatedProperties_When_IsUpdated()
		{
			//Arrange
			var document = new Document(Guid.NewGuid(), new TestDocumentContent(), new List<Guid>());
			var newContent = new TestDocumentContent()
			{
				Title = "TestTitle",
				Comment = "TestComment",
				Price = 1.23M,
				EventId = Guid.NewGuid()
			};

			//Act
			document.Update(newContent);

			//Assert
			document.Title.Should().Be(newContent.Title);
			document.Comment.Should().Be(newContent.Comment);
			document.Price.Should().Be(newContent.Price);
			document.EventId.Should().Be(newContent.EventId);
		}
	}
}
