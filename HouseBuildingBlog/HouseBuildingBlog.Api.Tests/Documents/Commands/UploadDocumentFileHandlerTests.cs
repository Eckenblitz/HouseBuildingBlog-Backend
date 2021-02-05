using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Services;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.TestBase.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Documents.Commands
{
	public class UploadDocumentFileHandlerTests : ActionResultTestBase
	{
		private UploadDocumentFileHandler SuT { get; }

		private readonly IWriteDocumentsAggregate _writeDocumentsAggregate;
		private readonly ITransformFileService _transformFileService;

		public UploadDocumentFileHandlerTests()
		{
			_writeDocumentsAggregate = Substitute.For<IWriteDocumentsAggregate>();
			_transformFileService = Substitute.For<ITransformFileService>();
			_transformFileService.TransformAsync(Arg.Any<IFormFile>()).Returns(new TestFile());

			SuT = new UploadDocumentFileHandler(_writeDocumentsAggregate, _transformFileService);
		}

		[Fact]
		public async Task Expect_OkResult_When_UploadWasSuccessful()
		{
			//Arrange / Act
			var result = await SuT.Handle(new UploadDocumentFileCommand(Guid.NewGuid(), Substitute.For<IFormFile>()), CancellationToken.None);

			//Assert
			CheckResult<OkResult>(result);
		}

		[Fact]
		public async Task Expect_NotFoundResult_When_DocumentWasNotFound()
		{
			//Arrange
			_writeDocumentsAggregate.UploadFileAsync(Arg.Any<Guid>(), Arg.Any<IDocumentFile>())
				   .Throws(new AggregateNotFoundException("", Guid.NewGuid()));

			//Act
			var result = await SuT.Handle(new UploadDocumentFileCommand(Guid.NewGuid(), Substitute.For<IFormFile>()), CancellationToken.None);

			//Assert
			CheckResult<NotFoundObjectResult>(result);
		}

		[Fact]
		public async Task Expect_BadRequestResult_When_ValidationFails()
		{
			//Arrange
			_writeDocumentsAggregate.UploadFileAsync(Arg.Any<Guid>(), Arg.Any<IDocumentFile>())
				   .Throws(new ValidationException(new List<DomainError>()));

			//Act
			var result = await SuT.Handle(new UploadDocumentFileCommand(Guid.NewGuid(), Substitute.For<IFormFile>()), CancellationToken.None);

			//Assert
			CheckResult<BadRequestObjectResult>(result);
		}
	}
}
