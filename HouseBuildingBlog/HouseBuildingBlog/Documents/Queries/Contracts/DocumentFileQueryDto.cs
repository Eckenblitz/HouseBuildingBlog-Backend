using HouseBuildingBlog.Domain;

namespace HouseBuildingBlog.Documents.Queries.Contracts
{
	public class DocumentFileQueryDto
	{
		public string FileName { get; set; }

		public byte[] BinaryData { get; set; }

		public static DocumentFileQueryDto From(Document document)
		{
			return new DocumentFileQueryDto()
			{
				FileName = document.File.FileName,
				BinaryData = document.File.BinaryData
			};
		}
	}
}
