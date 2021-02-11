using HouseBuildingBlog.Domain.Documents;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.TestBase.Documents
{
	public class TestDocumentContent : IDocumentContent
	{
		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }

		public IEnumerable<Guid> TagIds { get; set; }

		public TestDocumentContent() { }

		public TestDocumentContent(IDocumentContent content)
		{
			Title = content.Title;
			Comment = content.Comment;
			Price = content.Price;
			EventId = content.EventId;
			TagIds = content.TagIds;
		}
	}
}
