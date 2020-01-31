using System;

namespace HouseBuildingBlog.Domain
{
	public class Document
	{
		public Guid DocumentId { get; private set; }

		public string Title { get; private set; }

		public string Path { get; private set; }
	}
}
