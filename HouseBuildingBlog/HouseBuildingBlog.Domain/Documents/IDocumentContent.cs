using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocumentContent
	{
		string Title { get; }
		string? Comment { get; }
		decimal? Price { get; }
		Guid? EventId { get; }
	}
}
