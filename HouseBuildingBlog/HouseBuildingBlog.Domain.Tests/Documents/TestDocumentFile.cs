using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class TestDocumentFile : IDocumentFile
	{
		public Guid DocumentId { get; set; }

		public DocumentFileType FileType { get; set; }

		public string FileName { get; set; }

		public byte[] Binaries { get; set; }
	}
}
