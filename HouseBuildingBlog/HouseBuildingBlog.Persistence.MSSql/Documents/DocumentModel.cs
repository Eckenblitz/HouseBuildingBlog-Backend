using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.MSSql.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	//ToDo: Handle TagIds
	public class DocumentModel : IDocument
	{
		public Guid DocumentId { get; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }

		public IEnumerable<Guid> TagIds => AssignedTags?.Select(et => et.TagId);

		public ICollection<AssignedDocumentTagModel> AssignedTags { get; set; }

		//NavigationProperties

		public EventModel Event { get; set; }

		public DocumentFileModel File { get; set; }

		public DocumentModel() { }

		public DocumentModel(IDocument newDocument)
		{
			DocumentId = newDocument.DocumentId;
			AssignedTags = new List<AssignedDocumentTagModel>();
			Update(newDocument);
		}

		public void Update(IDocument document)
		{
			Title = document.Title;
			Comment = document.Comment;
			Price = document.Price;
			EventId = document.EventId;
			UpdateTags(document);
		}

		private void UpdateTags(IDocument update)
		{
			var assignedTags = new List<AssignedDocumentTagModel>(AssignedTags);

			//Create
			foreach (var tagId in update.TagIds.Except(assignedTags.Select(at => at.TagId)))
				AssignedTags.Add(new AssignedDocumentTagModel() { DocumentId = DocumentId, TagId = tagId });

			//Delete
			foreach (var assignedTag in assignedTags.Where(at => !update.TagIds.Contains(at.TagId)))
				AssignedTags.Remove(assignedTag);
		}
	}
}
