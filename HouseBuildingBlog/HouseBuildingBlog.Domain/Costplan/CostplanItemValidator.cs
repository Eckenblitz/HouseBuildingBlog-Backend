using HouseBuildingBlog.Domain.Validation;
using System.Collections.Generic;

namespace HouseBuildingBlog.Domain.Costplan
{
	public class CostplanItemValidator
	{
		public static ICollection<ValidationError> Validate(ICostplanItem item)
		{
			var validationErrors = new List<ValidationError>();

			if (item != null)
			{
				if (string.IsNullOrWhiteSpace(item.Name))
					validationErrors.Add(new ValidationError(CostplanErrorCodes.HasNoName));

				if (item.Number < 0)
					validationErrors.Add(new ValidationError(CostplanErrorCodes.NumberToLow));
			}
			else
			{
				validationErrors.Add(new ValidationError(CostplanErrorCodes.NoItemGiven));
			}

			return validationErrors;
		}
	}
}
