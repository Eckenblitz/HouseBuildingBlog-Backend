using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IFile
	{
		public Guid DocumentId { get; }

		public byte[] FileByteStream { get; }
	}
}
