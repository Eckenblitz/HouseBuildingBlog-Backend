using HouseBuildingBlog.Domain.Errors;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Validation
{
	public abstract class DomainValidatorBase
	{
		protected ICollection<DomainError> Errors { get; }

		protected DomainValidatorBase()
		{
			Errors = new List<DomainError>();
		}

		protected void AddError(string errorCode, params (string key, string value)[] parameters)
		{
			Errors.Add(new DomainError(errorCode, parameters));
		}
	}
}
