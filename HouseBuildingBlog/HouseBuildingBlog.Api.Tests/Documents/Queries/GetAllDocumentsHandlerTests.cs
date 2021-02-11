using FluentAssertions;
using HouseBuildingBlog.Api.Documents.Queries;
using HouseBuildingBlog.Api.Documents.Queries.Contracts;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.TestBase.Documents;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Documents.Queries
{
	public class GetAllDocumentsHandlerTests : ActionResultTestBase
	{
		private GetAllDocumentsHandler SuT { get; }
		private readonly IReadDocumentsAggregate _readDocumentsAggregate;

		public GetAllDocumentsHandlerTests()
		{
			_readDocumentsAggregate = Substitute.For<IReadDocumentsAggregate>();
			SuT = new GetAllDocumentsHandler(_readDocumentsAggregate);
		}

		[Fact]
		public async Task Expect_OkResultWithAllDocuments()
		{
			//Arrange
			var document1 = new TestDocument(Guid.NewGuid(), new TestDocumentContent()
			{
				Title = "Title",
				Comment = "Comment",
				Price = 1.23M,
				EventId = Guid.NewGuid(),
				TagIds = new List<Guid>() { Guid.NewGuid() }
			});
			var document2 = new TestDocument(Guid.NewGuid(), new TestDocumentContent()
			{
				Title = "Title2",
				Comment = "Comment2",
				Price = 1.24M,
				EventId = Guid.NewGuid(),
				TagIds = new List<Guid>() { Guid.NewGuid() }
			});
			var command = new GetAllDocumentsQuery();
			_readDocumentsAggregate.GetAllAsync().Returns(new List<TestDocument>() { document1, document2 });

			//Act
			var result = await SuT.Handle(command, CancellationToken.None);

			//Assert
			var documents = CheckResult<OkObjectResult, IEnumerable<DocumentQueryDto>>(result);
			documents.Should().Contain(d =>
				d.DocumentId == document1.DocumentId
				&& d.Title == document1.Title
				&& d.Comment == document1.Comment
				&& d.Price == document1.Price
				&& d.EventId == document1.EventId
				&& d.TagIds.SequenceEqual(document1.TagIds));
			documents.Should().Contain(d =>
				d.DocumentId == document2.DocumentId
				&& d.Title == document2.Title
				&& d.Comment == document2.Comment
				&& d.Price == document2.Price
				&& d.EventId == document2.EventId
				&& d.TagIds.SequenceEqual(document2.TagIds));
		}
	}
}
