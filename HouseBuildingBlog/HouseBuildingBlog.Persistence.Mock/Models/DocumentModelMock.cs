using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Persistence.Mock.Models
{
	class DocumentModelMock : IDocument
	{
		public Guid DocumentId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public string FileAdress { get; set; }

		public float Price { get; set; }
		public Guid EventId { get; set; }

		public DocumentModelMock(IDocument document)
		{
			DocumentId = document.DocumentId;
			Title = document.Title;
			Comment = document.Comment;
			FileAdress = document.FileAdress;
			Price = document.Price;
			EventId = document.EventId;
		}

		public void Update(IDocument document)
		{
			Title = document.Title;
			Comment = document.Comment;
			FileAdress = document.FileAdress;
			Price = document.Price;
			EventId = document.EventId;
		}
	}
}
