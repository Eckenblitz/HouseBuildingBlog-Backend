using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using System.Linq;

namespace HouseBuildingBlog.Domain.TestBase.Documents
{
	public static class DocumentTestExtensions
	{
		public static bool HasDocumentExpectedContent(this IDocument toCheck, IDocumentContent expectedContent)
		{
			return toCheck.Title == expectedContent.Title
				&& toCheck.Comment == expectedContent.Comment
				&& toCheck.Price == expectedContent.Price
				&& toCheck.EventId == expectedContent.EventId
				&& toCheck.TagIds.SequenceEqual(expectedContent.TagIds);
		}

		public static void CheckDocumentContent(this IDocument toCheck, IDocumentContent expectedContent)
		{
			toCheck.Title.Should().Be(expectedContent.Title);
			toCheck.Comment.Should().Be(expectedContent.Comment);
			toCheck.Price.Should().Be(expectedContent.Price);
			toCheck.EventId.Should().Be(expectedContent.EventId);
			toCheck.TagIds.Should().BeEquivalentTo(expectedContent.TagIds);
		}

		public static bool HasExpectedData(this IDocumentFile toCheck, IDocumentFile expected)
		{
			return toCheck.DocumentId == expected.DocumentId
				&& toCheck.FileName == expected.FileName
				&& toCheck.FileType == expected.FileType
				&& toCheck.Binaries.SequenceEqual(expected.Binaries);
		}

		public static void CheckDocumentFile(this IDocumentFile toCheck, IDocumentFile expected)
		{
			toCheck.DocumentId.Should().Be(expected.DocumentId);
			toCheck.FileName.Should().Be(expected.FileName);
			toCheck.FileType.Should().Be(expected.FileType);
			toCheck.Binaries.Should().BeEquivalentTo(expected.Binaries);
		}
	}
}
