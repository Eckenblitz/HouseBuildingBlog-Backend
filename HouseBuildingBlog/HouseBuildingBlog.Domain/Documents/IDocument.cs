using System;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IDocument
	{
		Guid DocumentId { get; }
		string Title { get; }
		string Comment { get; }
		string FileAdress { get; }
	}
}
