using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocument
	{
		Guid DocumentId { get; }
		string Title { get; }
		string Comment { get; }
		decimal Price { get; }
		Nullable<Guid> EventId { get; }
		IFile File { get; }
	}
}
