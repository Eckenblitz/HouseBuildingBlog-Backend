using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.Validation;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Images
{
	public class GalleryValidator : DomainValidatorBase<IGallery>
	{
		public override ICollection<DomainError> Validate(IGallery gallery)
		{
			if (string.IsNullOrWhiteSpace(gallery.Title))
				AddError(GalleryErrorCodes.HasNoTitle, ("aggregateId", gallery.GalleryId.ToString()));

			return Errors;
		}
	}
}
