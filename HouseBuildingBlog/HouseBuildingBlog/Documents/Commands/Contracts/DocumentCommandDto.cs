using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Api.Documents.Commands.Contracts
{
	public class DocumentCommandDto
	{
		public string Title { get; set; }

		public string Comment { get; set; }

		public string FileAdress { get; set; }

		public float Price { get; set; }
		public Guid EventId { get; set; }


		public DocumentCommandDto() { }

		public DocumentCommandDto(IDocument doc)
		{
			this.Title = doc.Title;
			this.Comment = doc.Comment;
			this.FileAdress = doc.FileAdress;
			this.Price = doc.Price;
		}
	}
}
