using System;

namespace HouseBuildingBlog.Documents.Commands.Contracts
{
	public class DocumentCommandDto
	{
		public Guid DocumentId { get; private set; }

		public string Title { get; private set; }

		public string Comment { get; private set; }

		public DocumentFileCommandDto File { get; private set; }
	}
}
