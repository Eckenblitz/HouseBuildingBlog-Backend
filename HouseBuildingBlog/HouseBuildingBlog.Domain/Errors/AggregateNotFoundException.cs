using System;

namespace HouseBuildingBlog.Domain.Errors
{
	public class AggregateNotFoundException : Exception
	{
		public DomainError Error { get; }

		public AggregateNotFoundException(string errorCode, Guid aggregateId)
		{
			Error = new DomainError(errorCode, ("aggregateId", aggregateId.ToString()));
		}
	}
}
