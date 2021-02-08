using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocument : IDocumentContent
	{
		Guid DocumentId { get; }

		IEnumerable<Guid> TagIds { get; }
	}
}
