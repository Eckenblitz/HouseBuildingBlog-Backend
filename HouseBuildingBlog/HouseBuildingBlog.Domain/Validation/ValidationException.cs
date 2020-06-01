using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Validation
{
	internal class ValidationException : Exception
	{
		public ICollection<ValidationError> ValidationErrors;

		public ValidationException(ICollection<ValidationError> validationErrors)
		{
			ValidationErrors = validationErrors;
		}
	}
}