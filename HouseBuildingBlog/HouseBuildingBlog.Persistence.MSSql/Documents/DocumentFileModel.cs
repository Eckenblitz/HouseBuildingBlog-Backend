using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Files;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class DocumentFileModel : IDocumentFile
	{
		public Guid DocumentId { get; }

		public FileType FileType { get; set; }

		public string FileName { get; set; }

		public byte[] Binaries { get; set; }

		public DocumentModel Document { get; set; }

		public DocumentFileModel() { }

		public DocumentFileModel(Guid documentId)
		{
			DocumentId = documentId;
		}

		public void Update(IDocumentFile file)
		{
			FileName = file.FileName;
			FileType = file.FileType;
			Binaries = file.Binaries;
		}
	}
}
