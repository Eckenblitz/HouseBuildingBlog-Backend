using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Api.Documents.Models
{
	public class File : IFile
	{
		public Guid DocumentId { get; private set; }

		public string FileName { get; private set; }

		public byte[] BinaryData { get; private set; }

		public File(IFile file)
		{
			DocumentId = file.DocumentId;
			FileName = file.FileName;
			BinaryData = file.BinaryData;
		}
	}
}
