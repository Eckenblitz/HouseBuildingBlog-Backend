namespace HouseBuildingBlog.Domain.Files
{
	public interface IFile
	{
		FileType FileType { get; }

		string FileName { get; }

		byte[] Binaries { get; set; }
	}
}
