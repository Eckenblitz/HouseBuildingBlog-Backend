using HouseBuildingBlog.Domain.Errors;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Tags
{
	internal static class TagValidator
	{
		internal static ICollection<DomainError> Validate(ITag tag)
		{
			ICollection<DomainError> validationErrors = new List<DomainError>();

			if (tag != null)
			{
				if (string.IsNullOrWhiteSpace(tag.Title))
					validationErrors.Add(new DomainError(TagErrorCodes.HasNoTitle, ("TagId", tag.TagId.ToString())));
			}
			else
			{
				validationErrors.Add(new DomainError(TagErrorCodes.TagWasNotGiven));
			}

			return validationErrors;
		}
	}
}
