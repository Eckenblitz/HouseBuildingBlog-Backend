﻿using HouseBuildingBlog.Domain.Errors;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Documents
{
	//ToDo make interface to substitute in UNitTests
	public class DocumentValidator
	{
		public static ICollection<DomainError> Validate(IDocument document)
		{
			ICollection<DomainError> validationErrors = new List<DomainError>();

			if (string.IsNullOrWhiteSpace(document.Title))
				validationErrors.Add(new DomainError(DocumentErrorCodes.HasNoTitle, ("DocumentId", document.DocumentId.ToString())));

			return validationErrors;
		}
	}
}
