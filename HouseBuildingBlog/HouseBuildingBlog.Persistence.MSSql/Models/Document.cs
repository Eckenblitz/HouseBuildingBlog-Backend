using System;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class Document
	{
		public Guid DocumentId { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public string FileName { get; set; }

		public string FilePath { get; set; }
	}
}