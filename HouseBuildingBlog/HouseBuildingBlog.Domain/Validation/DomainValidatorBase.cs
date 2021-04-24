using HouseBuildingBlog.Domain.Errors;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Validation
{
	public abstract class DomainValidatorBase<TDomainObject> : IDomainValidator<TDomainObject>
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

		public ICollection<DomainError> Validate(TDomainObject domainObject)
		{
			CheckAndAddErrors(domainObject);
			return Errors;
		}

		protected abstract void CheckAndAddErrors(TDomainObject domainObject);
	}
}
