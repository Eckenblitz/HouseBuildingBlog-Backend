using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Api.Documents.Commands.Contracts
{
	public class DocumentCommandDto
	{
		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal Price { get; set; }
		public Nullable<Guid> EventId { get; set; }


		public DocumentCommandDto() { }

		public DocumentCommandDto(IDocument doc)
		{
			this.Title = doc.Title;
			this.Comment = doc.Comment;
			this.Price = doc.Price;
		}
	}
}
