using System;

namespace HouseBuildingBlog.Domain.Documents
{
	//ToDo: rename to DocumentFile
	public interface IFile
	{
		public Guid DocumentId { get; }

		public string FileName { get; }

		public byte[] BinaryData { get; }
	}
}
