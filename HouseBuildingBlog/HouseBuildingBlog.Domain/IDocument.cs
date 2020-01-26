using System;

namespace HouseBuildingBlog.Domain
{
	public interface IDocument
	{
		Guid Id { get; }

		string Title { get; }

		string Comment { get; }

		string FileName { get; set; }

		BinaryType Type { get; }
	}
}
