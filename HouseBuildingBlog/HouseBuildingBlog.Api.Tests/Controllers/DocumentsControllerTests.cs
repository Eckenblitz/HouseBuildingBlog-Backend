using HouseBuildingBlog.Api.Controllers;
using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using HouseBuildingBlog.Api.Documents.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Api.Tests.Controllers
{
	public class DocumentsControllerTests
	{
		private DocumentsController SuT { get; }
		private readonly IMediator _mediator;

		public DocumentsControllerTests()
		{
			_mediator = Substitute.For<IMediator>();
			SuT = new DocumentsController(_mediator);
		}

		[Fact]
		public async Task Expect_CalledCreateDocumentCommand_When_CreateDocumentIsCalled()
		{
			//Arrange
			var data = new DocumentCommandDto()
			{
				Title = "Title",
				Comment = "Comment",
				Price = 1.23M,
				EventId = Guid.NewGuid()
			};

			//Act
			await SuT.CreateDocument(data);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<CreateDocumentCommand>(c =>
				c.Title == data.Title
				&& c.Comment == data.Comment
				&& c.Price == data.Price
				&& c.EventId == data.EventId));
		}

		[Fact]
		public async Task Expect_CalledUpdateDocumentCommand_When_UpdateDocumentIsCalled()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var data = new DocumentCommandDto()
			{
				Title = "Title",
				Comment = "Comment",
				Price = 1.23M,
				EventId = Guid.NewGuid()
			};

			//Act
			await SuT.UpdateDocument(documentId, data);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<UpdateDocumentCommand>(c =>
				c.DocumentId == documentId
				&& c.Title == data.Title
				&& c.Comment == data.Comment
				&& c.Price == data.Price
				&& c.EventId == data.EventId));
		}

		[Fact]
		public async Task Expect_CalledDeleteDocumentCommand_When_DeleteDocumentIsCalled()
		{
			//Arrange
			var documentId = Guid.NewGuid();

			//Act
			await SuT.DeleteDocument(documentId);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<DeleteDocumentCommand>(c => c.DocumentId == documentId));
		}

		[Fact]
		public async Task Expect_CalledGetAllDocumentsQuery_When_GetAllDocumentsIsCalled()
		{
			//Arrange / Act
			await SuT.GetAllDocuments();

			//Assert
			await _mediator.Received(1).Send(Arg.Any<GetAllDocumentsQuery>());
		}

		[Fact]
		public async Task Expect_CalledGetSingleDocumentQuery_When_GetSingleDocumentIsCalled()
		{
			//Arrange
			var documentId = Guid.NewGuid();

			//Act
			await SuT.GetSingleDocument(documentId);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<GetSingleDocumentQuery>(q => q.DocumentId == documentId));
		}

		[Fact]
		public async Task Expect_CalledUploadDocumentFileCommand_When_UploadFileIsCalled()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var file = Substitute.For<IFormFile>();

			//Act
			await SuT.UploadFile(documentId, file);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<UploadDocumentFileCommand>(c => c.DocumentId == documentId && c.File == file));
		}

		[Fact]
		public async Task Expect_CalledDownloadDocumentFileQuery_When_DownloadFileIsCalled()
		{
			//Arrange
			var documentId = Guid.NewGuid();

			//Act
			await SuT.DownloadFile(documentId);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<DownloadDocumentFileQuery>(c => c.DocumentId == documentId));
		}
	}
}
