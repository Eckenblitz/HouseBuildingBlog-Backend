using HouseBuildingBlog.Api.Controllers;
using HouseBuildingBlog.Api.Documents.Commands;
using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using HouseBuildingBlog.Api.Documents.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public async Task Given_CreateDocument_Expect_CreateDocumentCommand()
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
		public async Task Given_UpdateDocument_Expect_UpdateDocumentCommand()
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
		public async Task Given_DeleteDocument_Expect_DeleteDocumentCommand()
		{
			//Arrange
			var documentId = Guid.NewGuid();

			//Act
			await SuT.DeleteDocument(documentId);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<DeleteDocumentCommand>(c => c.DocumentId == documentId));
		}

		[Fact]
		public async Task Given_GetDocuments_Expect_GetAllDocumentsQuery_When_NoTagsArePassed()
		{
			//Arrange / Act
			await SuT.GetDocuments(new List<Guid>());

			//Assert
			await _mediator.Received(1).Send(Arg.Any<GetAllDocumentsQuery>());
		}

		[Fact]
		public async Task Given_GetDocuments_Expect_GetFilteredDocumentsQuerys_When_TagsArePassed()
		{
			//Arrange 
			var tagIds = new List<Guid>() { Guid.NewGuid() };

			// Act
			await SuT.GetDocuments(tagIds);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<GetFilteredDocumentsQuery>(q => q.TagIds.SequenceEqual(tagIds)));
		}

		[Fact]
		public async Task Given_GetSingleDocument_Expect_GetSingleDocumentQuery()
		{
			//Arrange
			var documentId = Guid.NewGuid();

			//Act
			await SuT.GetSingleDocument(documentId);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<GetSingleDocumentQuery>(q => q.DocumentId == documentId));
		}

		[Fact]
		public async Task Given_UploadFile_Expect_UploadDocumentFileCommand()
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
		public async Task Given_DownloadFile_Expect_DownloadDocumentFileQuery()
		{
			//Arrange
			var documentId = Guid.NewGuid();

			//Act
			await SuT.DownloadFile(documentId);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<DownloadDocumentFileQuery>(c => c.DocumentId == documentId));
		}

		[Fact]
		public async Task Given_AssignEventToDocument_Expect_AssignEventToDocumentCommand()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var eventId = Guid.NewGuid();

			//Act
			await SuT.AssignEventToDocument(documentId, eventId);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<AssignEventToDocumentCommand>(c => c.DocumentId == documentId && c.EventId == eventId));
		}

		[Fact]
		public async Task Given_UnassignDocumentFromEvent_Expect_UnassignDocumentFromEventCommand()
		{
			//Arrange
			var documentId = Guid.NewGuid();

			//Act
			await SuT.UnassignDocumentFromEvent(documentId);

			//Assert
			await _mediator.Received(1).Send(Arg.Is<UnassignEventFromDocumentCommand>(c => c.DocumentId == documentId));
		}
	}
}
