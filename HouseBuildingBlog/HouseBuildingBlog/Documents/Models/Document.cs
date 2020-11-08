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

		public IFile File { get; private set; }

		public Document() { }

		public Document(IDocument doc)
		{
			this.DocumentId = doc.DocumentId;
			this.Title = doc.Title;
			this.Comment = doc.Comment;
			this.Price = doc.Price;
			this.EventId = doc.EventId;
			File = doc.File;
		}

		public Document(CreateDocumentCommand command)
		{
			this.DocumentId = Guid.NewGuid();
			this.Title = command.Data.Title;
			this.Comment = command.Data.Comment;
			this.Price = command.Data.Price;
			this.EventId = command.Data.EventId;
		}

		public Document(UpdateDocumentCommand command)
		{
			this.DocumentId = command.Id;
			this.Title = command.Data.Title;
			this.Comment = command.Data.Comment;
			this.Price = command.Data.Price;
			this.EventId = command.Data.EventId;
		}
	}
}
