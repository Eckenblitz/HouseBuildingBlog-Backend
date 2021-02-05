using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.TestBase.Files;
using System;

namespace HouseBuildingBlog.Domain.TestBase.Documents
{
	public class TestDocumentFile : TestFile, IDocumentFile
	{
		public Guid DocumentId { get; set; }

		public TestDocumentFile() : base() { }

		public TestDocumentFile(IDocumentFile file) : base(file)
		{
			DocumentId = file.DocumentId;
		}
	}
}
