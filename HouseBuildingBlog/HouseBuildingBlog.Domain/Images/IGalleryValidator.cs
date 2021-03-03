using HouseBuildingBlog.Domain.Errors;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Images
{
	public interface IGalleryValidator
	{
		ICollection<DomainError> Validate(IGallery gallery);
	}
}
