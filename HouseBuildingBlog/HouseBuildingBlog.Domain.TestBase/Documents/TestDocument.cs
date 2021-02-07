using HouseBuildingBlog.Domain.Documents;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.TestBase.Documents
{
	public class TestDocument : IDocument
	{
		public Guid DocumentId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }

		public IList<Guid> TagIds { get; set; }

		public TestDocument() { }

		public TestDocument(Guid documentId, IDocumentContent content)
		{
			DocumentId = documentId;
			Title = content.Title;
			Comment = content.Comment;
			Price = content.Price;
			EventId = content.EventId;
			TagIds = new List<Guid>();
		}

		public TestDocument(IDocument document)
		{
			DocumentId = document.DocumentId;
			Title = document.Title;
			Comment = document.Comment;
			Price = document.Price;
			EventId = document.EventId;
			TagIds = document.TagIds;
		}
	}
}
