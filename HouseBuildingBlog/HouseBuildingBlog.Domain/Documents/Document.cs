using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public class Document : IDocument
	{
		public Guid DocumentId { get; }

		public string Title { get; private set; }

		public string? Comment { get; private set; }

		public decimal? Price { get; private set; }

		public Guid? EventId { get; private set; }

		public Document(Guid documentId, IDocumentContent content)
		{
			DocumentId = documentId;
			Update(content);
		}

		public void Update(IDocumentContent content)
		{
			Title = content.Title;
			Comment = content.Comment;
			Price = content.Price;
			EventId = content.EventId;
		}
	}
}
