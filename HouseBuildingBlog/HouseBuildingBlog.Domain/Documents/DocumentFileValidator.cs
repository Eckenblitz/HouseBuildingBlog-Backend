using HouseBuildingBlog.Domain.Errors;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Documents
{
	public static class DocumentFileValidator
	{
		public static ICollection<DomainError> Validate(IDocumentFile documentFile)
		{
			ICollection<DomainError> validationErrors = new List<DomainError>();

			if (documentFile.FileType != Files.FileType.PDF && documentFile.FileType != Files.FileType.TXT)
				validationErrors.Add(new DomainError(DocumentErrorCodes.FileTypeNotAllowed, ("DocumentId", documentFile.DocumentId.ToString())));

			return validationErrors;
		}
	}
}
