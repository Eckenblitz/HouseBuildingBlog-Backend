namespace HouseBuildingBlog.Documents.Commands.Contracts
{
	public class DocumentFileCommandDto
	{
		public string FileName { get; set; }

		public byte[] BinaryData { get; set; }
	}
}