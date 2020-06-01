using HouseBuildingBlog.Domain.Validation;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Tags
{
	internal static class TagValidator
	{
		internal static ICollection<ValidationError> Validate(ITag tag)
		{
			ICollection<ValidationError> validationErrors = new List<ValidationError>();

			if (tag != null)
			{
				if (string.IsNullOrWhiteSpace(tag.Title))
					validationErrors.Add(new ValidationError(TagErrorCodes.HasNoTitle, ("TagId", tag.TagId.ToString())));
			}
			else
			{
				validationErrors.Add(new ValidationError(TagErrorCodes.TagWasNotGiven));
			}

			return validationErrors;
		}
	}
}
