using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Api.Documents.Models
{
	public class File
	{
		public Guid DocumentId { get; private set; }

		public byte[] FileByteStream { get; private set; }

		public File(IFile file)
		{
			DocumentId = file.DocumentId;
			FileByteStream = file.FileByteStream;
		}
	}
}
