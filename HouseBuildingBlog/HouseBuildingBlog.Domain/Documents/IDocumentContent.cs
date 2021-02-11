using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocumentContent
	{
		string Title { get; }

		string? Comment { get; }

		decimal? Price { get; }

		Guid? EventId { get; }

		IEnumerable<Guid> TagIds { get; }
	}
}
