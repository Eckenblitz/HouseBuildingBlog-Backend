using HouseBuildingBlog.Domain.Validation;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Documents
{
	class DocumentValidator
	{
		public static ICollection<ValidationError> Validate(IDocument document)
		{
			ICollection<ValidationError> validationError = new List<ValidationError>();
			if (document != null)
			{
				if (string.IsNullOrWhiteSpace(document.Title))
					validationError.Add(new ValidationError(DocumentErrorCodes.HasNoTitle, ("DocumentId", document.DocumentId.ToString())));
			}
			else
			{
				validationError.Add(new ValidationError(DocumentErrorCodes.DocumentWasNotGiven));
			}
			return validationError;
		}


	}
}
