using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Errors
{
	public class ValidationException : Exception
	{
		public ICollection<DomainError> ValidationErrors;

		public ValidationException(ICollection<DomainError> validationErrors)
		{
			ValidationErrors = validationErrors;
		}
	}
}