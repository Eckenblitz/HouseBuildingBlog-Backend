namespace HouseBuildingBlog.Domain
{
	public class File
	{
		public string FileName { get; private set; }

		public byte[] BinaryData { get; private set; }

		public File(string fileName, byte[] binaryData)
		{
			FileName = fileName;
			BinaryData = binaryData;
		}
	}
}