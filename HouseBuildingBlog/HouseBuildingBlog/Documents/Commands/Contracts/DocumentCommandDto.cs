using System;

namespace HouseBuildingBlog.Api.Documents.Commands.Contracts
{
	public class DocumentCommandDto
	{
		public string Title { get; set; }

		public string? Comment { get; set; }

		public decimal? Price { get; set; }

		public Guid? EventId { get; set; }
	}
}
