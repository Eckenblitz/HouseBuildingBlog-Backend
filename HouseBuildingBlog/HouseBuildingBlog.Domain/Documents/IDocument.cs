using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocument : IDocumentContent
	{
		Guid DocumentId { get; }
	}
}
