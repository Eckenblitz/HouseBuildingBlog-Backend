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
		public void Given_NewDocument_Expect_FilledProperties()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var content = new TestDocumentContent()
			{
				Title = "TestTitle",
				Comment = "TestComment",
				Price = 1.23M,
				EventId = Guid.NewGuid(),
				TagIds = new List<Guid>() { Guid.NewGuid() }
			};

			//Act
			var newDocument = new Document(documentId, content);

			//Assert
			newDocument.DocumentId.Should().Be(documentId);
			newDocument.Title.Should().Be(content.Title);
			newDocument.Comment.Should().Be(content.Comment);
			newDocument.Price.Should().Be(content.Price);
			newDocument.EventId.Should().Be(content.EventId);
			newDocument.TagIds.Should().BeEquivalentTo(content.TagIds);
		}

		[Fact]
		public void Given_Update_Expect_UpdatedProperties()
		{
			//Arrange
			var document = new Document(Guid.NewGuid(), new TestDocumentContent());
			var newContent = new TestDocumentContent()
			{
				Title = "TestTitle",
				Comment = "TestComment",
				Price = 1.23M,
				EventId = Guid.NewGuid(),
				TagIds = new List<Guid>() { Guid.NewGuid() }
			};

			//Act
			document.Update(newContent);

			//Assert
			document.Title.Should().Be(newContent.Title);
			document.Comment.Should().Be(newContent.Comment);
			document.Price.Should().Be(newContent.Price);
			document.EventId.Should().Be(newContent.EventId);
			document.TagIds.Should().BeEquivalentTo(newContent.TagIds);
		}

		[Fact]
		public void Given_AssignEvent_Expect_Updated_EventId()
		{
			//Arrange
			var document = new Document(Guid.NewGuid(), new TestDocumentContent());
			var eventId = Guid.NewGuid();

			//Act
			document.AssignEvent(eventId);

			//Assert
			document.EventId.Should().Be(eventId);
		}

		[Fact]
		public void Given_UnassignEvent_Expect_Empty_EventId()
		{
			//Arrange
			var document = new Document(Guid.NewGuid(), new TestDocumentContent() { EventId = Guid.NewGuid() });

			//Act
			document.UnassignEvent();

			//Assert
			document.EventId.Should().BeNull();
		}
	}
}
