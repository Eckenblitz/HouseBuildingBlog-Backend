using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Persistence.Mock.Models
{
	public class DocumentModelMock : IDocument
	{
		public Guid DocumentId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal Price { get; set; }
		public Nullable<Guid> EventId { get; set; }
		public IFile File { get; set; }
		public DocumentModelMock(IDocument document)
		{
			DocumentId = document.DocumentId;
			Title = document.Title;
			Comment = document.Comment;
			Price = document.Price;
			EventId = document.EventId;
		}

		public void Update(IDocument document)
		{
			Title = document.Title;
			Comment = document.Comment;
			Price = document.Price;
			EventId = document.EventId;
		}

		public void UpdateFile(IFile file)
		{
			File = file;
		}
	}
}
