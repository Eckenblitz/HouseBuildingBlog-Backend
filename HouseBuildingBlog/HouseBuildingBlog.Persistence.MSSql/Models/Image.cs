using System;

namespace HouseBuildingBlog.Persistence.MSSql.Models
{
	public class Image
	{
		public Guid ImageId { get; set; }

		public string Comment { get; set; }

		public string FileName { get; set; }

		public string FilePath { get; set; }
	}
}