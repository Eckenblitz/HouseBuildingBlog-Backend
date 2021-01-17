using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace HouseBuildingBlog.Api.Tests
{
	public abstract class ActionResultTestBase
	{
		public TResult CheckResult<TResult>(IActionResult result)
		{
			return result.Should().BeOfType<TResult>().Subject;
		}

		public void CheckResult<TResult, TValue>(IActionResult actionResult, Expression<Func<TValue, bool>> checkValueExpression = null)
			where TResult : ObjectResult
		{
			var castedResutl = CheckResult<TResult>(actionResult);
			var valueObject = castedResutl.Value.Should().BeOfType<TValue>().Subject;
			checkValueExpression?.Compile()(valueObject).Should().BeTrue();
		}

		public TValue CheckResult<TResult, TValue>(IActionResult actionResult)
			where TResult : ObjectResult
		{
			var castedResutl = CheckResult<TResult>(actionResult);
			return castedResutl.Value.Should().BeAssignableTo<TValue>().Subject;
		}
	}
}
