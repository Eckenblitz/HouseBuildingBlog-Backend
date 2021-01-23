using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocumentFile
	{
		Guid DocumentId { get; }

		DocumentFileType FileType { get; }

		string FileName { get; }

		byte[] Binaries { get; }
	}
}
