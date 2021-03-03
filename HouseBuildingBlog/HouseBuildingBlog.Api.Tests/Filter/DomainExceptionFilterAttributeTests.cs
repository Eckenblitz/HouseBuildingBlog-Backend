using FluentAssertions;
using HouseBuildingBlog.Api.Filter;
using HouseBuildingBlog.Domain.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Filter
{
	public class DomainExceptionFilterAttributeTests
	{
		private DomainExceptionFilterAttribute SuT { get; }

		public DomainExceptionFilterAttributeTests()
		{
			SuT = new DomainExceptionFilterAttribute();
		}

		[Fact]
		public void Given_NotDomainException_Expect_InternalServerError()
		{
			//Arrange
			var exceptionContext = InitializeExceptionContext();
			exceptionContext.Exception = new Exception();

			//Act
			SuT.OnException(exceptionContext);

			//Assert
			var result = exceptionContext.Result.CheckResult<StatusCodeResult>();
			result.StatusCode.Should().Be((int)System.Net.HttpStatusCode.InternalServerError);
		}

		[Fact]
		public void Given_AggregateNotFoundException_Expect_NotFoundResult()
		{
			//Arrange
			var aggregateId = Guid.NewGuid();
			var errorCode = "TEST";
			var exceptionContext = InitializeExceptionContext();
			exceptionContext.Exception = new AggregateNotFoundException(errorCode, aggregateId);

			//Act
			SuT.OnException(exceptionContext);

			//Assert
			exceptionContext.Result.CheckResult<NotFoundObjectResult, DomainError>(error =>
				error.ErrorCode == errorCode
				&& error.ErrorParameters["aggregateId"] == aggregateId.ToString());
		}

		[Fact]
		public void Given_ValidationException_Expect_BadRequestResult()
		{
			//Arrange
			var aggregateId = Guid.NewGuid();
			var errorCode = "TEST";
			var exceptionContext = InitializeExceptionContext();
			exceptionContext.Exception =
				new ValidationException(
					new List<DomainError>()
					{ new DomainError(errorCode, ("aggregateId", aggregateId.ToString())) });

			//Act
			SuT.OnException(exceptionContext);

			//Assert
			exceptionContext.Result.CheckResult<BadRequestObjectResult, List<DomainError>>(errors =>
				errors.Any(e => e.ErrorCode == errorCode && e.ErrorParameters["aggregateId"] == aggregateId.ToString()));
		}

		private static ExceptionContext InitializeExceptionContext()
		{
			var actionContext = new ActionContext()
			{
				HttpContext = new DefaultHttpContext(),
				RouteData = new RouteData(),
				ActionDescriptor = new ActionDescriptor()
			};
			return new ExceptionContext(actionContext, new List<IFilterMetadata>());
		}
	}
}
