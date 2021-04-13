using HouseBuildingBlog.Domain.Files;
using System;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IImageFile : IFile
	{
		Guid ImageId { get; }
	}
}
