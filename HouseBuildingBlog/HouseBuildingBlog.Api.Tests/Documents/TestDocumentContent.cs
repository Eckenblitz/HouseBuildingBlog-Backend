using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Api.Tests.Documents
{
	public class TestDocumentContent : IDocumentContent
	{
		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }
	}
}
