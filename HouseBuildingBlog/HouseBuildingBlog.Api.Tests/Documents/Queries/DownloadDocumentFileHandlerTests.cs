using HouseBuildingBlog.Api.Documents.Queries;
using HouseBuildingBlog.Api.Services;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using HouseBuildingBlog.Domain.Files;
using HouseBuildingBlog.Persistence.MSSql.Files;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Documents.Queries
{
	public class DownloadDocumentFileHandlerTests
	{
		private DownloadDocumentFileHandler SuT { get; }

		private readonly IReadDocumentsAggregate _readDocumentsAggregate;
		private readonly IFileResponseService _fileResponseService;

		public DownloadDocumentFileHandlerTests()
		{
			_readDocumentsAggregate = Substitute.For<IReadDocumentsAggregate>();
			_fileResponseService = Substitute.For<IFileResponseService>();
			_fileResponseService.CreateFileContentResult(Arg.Any<IFile>())
				.Returns(new FileContentResult(new byte[] { }, "application/pdf"));

			SuT = new DownloadDocumentFileHandler(_readDocumentsAggregate, _fileResponseService);
		}

		[Fact]
		public async Task Expect_FileContentResult_When_DocumentWasFound()
		{
			//Arrange / Act
			var result = await SuT.Handle(new DownloadDocumentFileQuery(Guid.NewGuid()), CancellationToken.None);

			//Assert
			result.CheckResult<FileContentResult>();
		}

		[Fact]
		public async Task Expect_NotFoundResult_WhenDocumentWasNotFound()
		{
			//Arrange 
			var documentId = Guid.NewGuid();
			_readDocumentsAggregate.DownloadFileAsync(Arg.Is<Guid>(documentId))
				.Throws(new AggregateNotFoundException(DocumentErrorCodes.DocumentNotFound, documentId));

			// Act
			var result = await SuT.Handle(new DownloadDocumentFileQuery(documentId), CancellationToken.None);

			//Assert
			result.CheckResult<NotFoundObjectResult, AggregateNotFoundException>(ex =>
				ex.Error.ErrorCode == DocumentErrorCodes.DocumentNotFound
				&& ex.Error.ErrorParameters["aggregateId"] == documentId.ToString());
		}

		[Fact]
		public async Task Expect_NotFoundResult_WhenFileWasNotFound()
		{
			//Arrange 
			var documentId = Guid.NewGuid();
			_readDocumentsAggregate.DownloadFileAsync(Arg.Any<Guid>())
				.Throws(new FileNotFoundException<IDocumentFile>(null, null));

			// Act
			var result = await SuT.Handle(new DownloadDocumentFileQuery(documentId), CancellationToken.None);

			//Assert
			result.CheckResult<NotFoundObjectResult, FileNotFoundException<IDocumentFile>>();
		}
	}
}
