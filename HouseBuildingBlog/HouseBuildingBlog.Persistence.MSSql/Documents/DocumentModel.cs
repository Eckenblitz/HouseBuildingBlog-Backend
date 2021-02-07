using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.MSSql.Events;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	//ToDo: Handle TagIds
	public class DocumentModel : IDocument
	{
		public DocumentModel() { }
		public DocumentModel(IDocument newDocument)
		{
			DocumentId = newDocument.DocumentId;
			Update(newDocument);
		}

		public Guid DocumentId { get; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }

		public IList<Guid> TagIds => throw new NotImplementedException();

		//NavigationProperties

		public EventModel Event { get; set; }

		public DocumentFileModel File { get; set; }

		public void Update(IDocument document)
		{
			Title = document.Title;
			Comment = document.Comment;
			Price = document.Price;
			EventId = document.EventId;
		}
	}
}
