using HouseBuildingBlog.Domain.Files;

namespace HouseBuildingBlog.Domain.TestBase.Files
{
	public class TestFile : IFile
	{
		public FileType FileType { get; set; }

		public string FileName { get; set; }

		public byte[] Binaries { get; set; }

		public TestFile()
		{ }

		public TestFile(IFile file)
		{
			FileName = file.FileName;
			FileType = file.FileType;
			Binaries = file.Binaries;
		}
	}
}
