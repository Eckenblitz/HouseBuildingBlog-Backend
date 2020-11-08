using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IFile
	{
		public Guid DocumentId { get; }

		public string FileName { get; }

		public byte[] BinaryData { get; }
	}
}
