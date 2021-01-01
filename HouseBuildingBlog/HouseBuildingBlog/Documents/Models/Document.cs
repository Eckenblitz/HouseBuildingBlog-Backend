using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Api.Documents.Models
{
	public class Document : IDocument
	{
		public Guid DocumentId { get; private set; }

		public string Title { get; private set; }

		public string Comment { get; private set; }

		public decimal Price { get; private set; }

		public Nullable<Guid> EventId { get; private set; }

		public Document() { }

		public Document(IDocument doc)
		{
			DocumentId = doc.DocumentId;
			Title = doc.Title;
			Comment = doc.Comment;
			Price = doc.Price;
			EventId = doc.EventId;
		}

		public Document(CreateDocumentCommand command)
		{
			DocumentId = Guid.NewGuid();
			Title = command.Data.Title;
			Comment = command.Data.Comment;
			Price = command.Data.Price;
			EventId = command.Data.EventId;
		}

		public Document(UpdateDocumentCommand command)
		{
			DocumentId = command.DocumentId;
			Title = command.Data.Title;
			Comment = command.Data.Comment;
			Price = command.Data.Price;
			EventId = command.Data.EventId;
		}
	}
}
