namespace HouseBuildingBlog.Domain.Files
{
	public class File : IFile
	{
		public string FileName { get; }

		public byte[] Binaries { get; }

		public FileType FileType { get; }

		public File(string fileName, FileType fileType, byte[] binaries)
		{
			FileName = fileName;
			Binaries = binaries;
			FileType = fileType;
		}
	}
}
