using HouseBuildingBlog.Domain.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HouseBuildingBlog.Api.Filter
{
	public class DomainExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			IActionResult result;

			switch (context.Exception)
			{
				case AggregateNotFoundException ex:
					result = new NotFoundObjectResult(ex.Error);
					break;
				case ValidationException ex:
					result = new BadRequestObjectResult(ex.ValidationErrors);
					break;
				default:
					result = new StatusCodeResult((int)System.Net.HttpStatusCode.InternalServerError);
					break;
			}

			context.Result = result;

			base.OnException(context);
		}
	}
}
