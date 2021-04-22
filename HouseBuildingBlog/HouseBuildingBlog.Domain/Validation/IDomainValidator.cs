using HouseBuildingBlog.Domain.Errors;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Validation
{
	public interface IDomainValidator<TDomainObject>
	{
		ICollection<DomainError> Validate(TDomainObject domainObject);
	}
}
