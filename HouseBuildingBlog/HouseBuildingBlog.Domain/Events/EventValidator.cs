using HouseBuildingBlog.Domain.Errors;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Events
{
	public static class EventValidator
	{
		public static ICollection<DomainError> Validate(IEvent @event)
		{
			ICollection<DomainError> validationErrors = new List<DomainError>();

			if (@event != null)
			{
				if (string.IsNullOrWhiteSpace(@event.Title))
					validationErrors.Add(new DomainError(EventErrorCodes.HasNoTitle, ("EventId", @event.EventId.ToString())));
			}
			else
			{
				validationErrors.Add(new DomainError(EventErrorCodes.EventWasNotGiven));
			}

			return validationErrors;
		}
	}
}
