using HouseBuildingBlog.Persistence.MSSql.Tags;
using System;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class AssignedDocumentTagModel
	{
		public Guid DocumentId { get; set; }

		public DocumentModel Document { get; set; }

		public Guid TagId { get; set; }

		public TagModel Tag { get; set; }
	}
}
