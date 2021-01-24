using HouseBuildingBlog.Domain.Files;
using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocumentFile : IFile
	{
		Guid DocumentId { get; }
	}
}
