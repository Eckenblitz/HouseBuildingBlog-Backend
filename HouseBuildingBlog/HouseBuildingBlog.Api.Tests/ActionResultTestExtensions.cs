using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace HouseBuildingBlog.Api.Tests
{
	public static class ActionResultTestExtensions
	{
		public static TResult CheckResult<TResult>(this IActionResult result)
		{
			return result.Should().BeOfType<TResult>().Subject;
		}

		public static void CheckResult<TResult, TValue>(this IActionResult actionResult, Expression<Func<TValue, bool>> checkValueExpression = null)
			where TResult : ObjectResult
		{
			var castedResutl = CheckResult<TResult>(actionResult);
			var valueObject = castedResutl.Value.Should().BeOfType<TValue>().Subject;
			checkValueExpression?.Compile()(valueObject).Should().BeTrue();
		}

		public static TValue CheckResult<TResult, TValue>(this IActionResult actionResult)
			where TResult : ObjectResult
		{
			var castedResutl = CheckResult<TResult>(actionResult);
			return castedResutl.Value.Should().BeAssignableTo<TValue>().Subject;
		}
	}
}
