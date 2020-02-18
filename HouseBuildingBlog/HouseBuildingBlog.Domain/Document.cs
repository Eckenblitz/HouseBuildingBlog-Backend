using System;

namespace HouseBuildingBlog.Domain
{
	public class Document
	{
		public Guid DocumentId { get; private set; }

		public string Title { get; private set; }

		public string Comment { get; private set; }

		public File File { get; private set; }

		public Document(Guid documentId, string title)
		{
			DocumentId = documentId;
			Title = title;
		}

		public void UpdateComment(string comment)
		{
			Comment = comment;
		}

		public void UpdateFile(string fileName, byte[] binaryData)
		{
			File = new File(fileName, binaryData);
		}

		public void UpdateTitle(string title)
		{
			Title = title;
		}
	}
}
