using HouseBuildingBlog.Domain.Files;
using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public class DocumentFile : File, IDocumentFile
	{
		public Guid DocumentId { get; }

		public DocumentFile(Guid documentId, IFile file) : base(file.FileName, file.FileType, file.Binaries)
		{
			DocumentId = documentId;
		}
	}
}
