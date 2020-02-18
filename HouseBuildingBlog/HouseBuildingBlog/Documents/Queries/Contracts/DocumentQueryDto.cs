using HouseBuildingBlog.Domain;
using System;

namespace HouseBuildingBlog.Documents.Queries.Contracts
{
	public class DocumentQueryDto
	{
		public Guid DocumentId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public static DocumentQueryDto From(Document document)
		{
			return new DocumentQueryDto()
			{
				DocumentId = document.DocumentId,
				Title = document.Title,
				Comment = document.Comment
			};
		}
	}
}
