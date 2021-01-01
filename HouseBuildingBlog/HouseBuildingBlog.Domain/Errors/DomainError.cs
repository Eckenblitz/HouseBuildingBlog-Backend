using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Domain.Errors
{
	public class DomainError
	{
		public string ErrorCode { get; set; }

		public IDictionary<string, string> ErrorParameters { get; set; }

		public DomainError(string errorCode, params (string key, string value)[] parameters)
		{
			ErrorCode = errorCode;
			ErrorParameters = new Dictionary<string, string>(parameters.Select(p => KeyValuePair.Create(p.key, p.value)));
		}
	}
}
