using HouseBuildingBlog.Domain.Files;
using System;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IImage : IFile
	{
		Guid ImageId { get; }

		string Title { get; }

		string Comment { get; }
	}
}
