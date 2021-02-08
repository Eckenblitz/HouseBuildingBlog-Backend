using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Documents
{
	public class Document : IDocument
	{
		public Guid DocumentId { get; }

		public string Title { get; private set; }

		public string? Comment { get; private set; }

		public decimal? Price { get; private set; }

		public Guid? EventId { get; private set; }

		public IEnumerable<Guid> TagIds { get; }

		public Document(Guid documentId, IDocumentContent content, IEnumerable<Guid> tagIds)
		{
			DocumentId = documentId;
			Update(content);
			TagIds = new List<Guid>(tagIds);
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
