using HouseBuildingBlog.Domain.Documents;
using System;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class TestDocument : IDocument
	{
		public Guid DocumentId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }
	}
}
