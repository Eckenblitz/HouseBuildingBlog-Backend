using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Api.Documents.Commands.Contracts
{
	public class DocumentCommandDto
	{
		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal Price { get; set; }

		public Guid? EventId { get; set; }


		public DocumentCommandDto() { }

		public DocumentCommandDto(IDocument doc)
		{
			Title = doc.Title;
			Comment = doc.Comment;
			Price = doc.Price;
			EventId = doc.EventId;
		}
	}
}
