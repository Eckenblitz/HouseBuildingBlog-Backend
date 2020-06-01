using HouseBuildingBlog.Domain.Validation;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Events
{
	public static class EventValidator
	{
		public static ICollection<ValidationError> Validate(IEvent @event)
		{
			ICollection<ValidationError> validationErrors = new List<ValidationError>();

			if (@event != null)
			{
				if (string.IsNullOrWhiteSpace(@event.Title))
					validationErrors.Add(new ValidationError(EventErrorCodes.HasNoTitle, ("EventId", @event.EventId.ToString())));
			}
			else
			{
				validationErrors.Add(new ValidationError(EventErrorCodes.EventWasNotGiven));
			}

			return validationErrors;
		}
	}
}
