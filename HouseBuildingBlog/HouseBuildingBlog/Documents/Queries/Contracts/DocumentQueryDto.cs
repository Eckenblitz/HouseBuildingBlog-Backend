using HouseBuildingBlog.Domain.Documents;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Documents.Queries.Contracts
{
	public class DocumentQueryDto
	{
		public Guid DocumentId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }

		public IEnumerable<Guid> TagIds { get; set; }

		public DocumentQueryDto(IDocument doc)
		{
			DocumentId = doc.DocumentId;
			Title = doc.Title;
			Comment = doc.Comment;
			Price = doc.Price;
			EventId = doc.EventId;
			TagIds = doc.TagIds;
		}
	}
}
