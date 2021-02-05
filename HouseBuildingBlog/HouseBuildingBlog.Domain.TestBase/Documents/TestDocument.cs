using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Domain.TestBase.Documents
{
	public class TestDocument : IDocument
	{
		public Guid DocumentId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }

		public TestDocument() { }

		public TestDocument(IDocument document)
		{
			DocumentId = document.DocumentId;
			Title = document.Title;
			Comment = document.Comment;
			Price = document.Price;
			EventId = document.EventId;
		}
	}
}
