namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocumentFile
	{
		DocumentFileType FileType { get; }

		string FileName { get; }

		byte[] Binaries { get; }
	}
}
