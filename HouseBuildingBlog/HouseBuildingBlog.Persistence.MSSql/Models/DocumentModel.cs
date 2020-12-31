using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class DocumentModel : IDocument
	{
		public DocumentModel() { }
		public DocumentModel(IDocument newDocument)
		{
			DocumentId = newDocument.DocumentId;
			Title = newDocument.Title;
			Comment = newDocument.Comment;
			Price = newDocument.Price;
			EventId = newDocument.EventId;
		}

		public Guid DocumentId { get; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal Price { get; set; }

		public Nullable<Guid> EventId { get; set; }

		public EventModel Event { get; set; }

		public void Update(IDocument document)
		{
			Title = document.Title;
			Comment = document.Comment;
			Price = document.Price;
			EventId = document.EventId;
		}
	}
}
