using HouseBuildingBlog.Domain.Validation;

namespace HouseBuildingBlog.Domain.Images
{
	public class GalleryValidator : DomainValidatorBase<IGallery>
	{
		protected override void CheckAndAddErrors(IGallery gallery)
		{
			if (string.IsNullOrWhiteSpace(gallery.Title))
				AddError(GalleryErrorCodes.HasNoTitle, ("galleryId", gallery.GalleryId.ToString()));
		}
	}
}
