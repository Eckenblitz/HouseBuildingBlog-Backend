using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Validation
{
    public class ValidationException : Exception
    {
        public ICollection<ValidationError> ValidationErrors;

        public ValidationException(ICollection<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
    }
}