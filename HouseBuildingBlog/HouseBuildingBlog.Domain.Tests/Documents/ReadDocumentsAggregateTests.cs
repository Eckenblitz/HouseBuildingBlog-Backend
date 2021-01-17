using FluentAssertions;
using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Domain.Errors;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HouseBuildingBlog.Domain.Tests.Documents
{
	public class ReadDocumentsAggregateTests
	{
		private readonly ReadDocumentsAggregate SuT;
		private readonly IReadDocumentsRepository _readDocumentsRepository;

		public ReadDocumentsAggregateTests()
		{
			_readDocumentsRepository = Substitute.For<IReadDocumentsRepository>();
			SuT = new ReadDocumentsAggregate(_readDocumentsRepository);
		}

		[Fact]
		public async Task Expect_Document_When_DocumentExistInRepository()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var document = new Document(documentId, new TestDocumentContent());
			_readDocumentsRepository.GetByIdAsync(Arg.Is(documentId)).Returns(document);

			//Act
			var result = await SuT.GetByIdAsync(documentId);

			//Assert
			result.Should().NotBeNull();
			result.DocumentId.Should().Be(document.DocumentId);
			result.Title.Should().Be(document.Title);
			result.Comment.Should().Be(document.Comment);
			result.Price.Should().Be(document.Price);
			result.EventId.Should().Be(document.EventId);
		}

		[Fact]
		public async Task Expect_AggregateNotFoundException_When_DocumentIsNotFound()
		{
			//Arrange
			var documentId = Guid.NewGuid();
			var document = new Document(documentId, new TestDocumentContent());
			_readDocumentsRepository.GetByIdAsync(Arg.Any<Guid>()).Returns((IDocument)null);

			//Act //Assert
			Func<Task<IDocument>> act = async () => await SuT.GetByIdAsync(documentId);
			var exception = (await act.Should().ThrowAsync<AggregateNotFoundException>()).And;
			exception.Error.ErrorCode.Should().Be(DocumentErrorCodes.DocumentNotFound);
			exception.Error.ErrorParameters["aggregateId"].Should().Be(documentId.ToString());
		}

		//GetAll
		[Fact]
		public async Task Expect_AllDocuments_When_GetAllIsCalled()
		{
			//Arrange
			var document1 = new Document(Guid.NewGuid(), new TestDocumentContent());
			var document2 = new Document(Guid.NewGuid(), new TestDocumentContent());
			_readDocumentsRepository.GetAllAsync().Returns(new List<IDocument>() { document1, document2 });

			//Act
			var documents = await SuT.GetAllAsync();

			//Assert
			documents.Should().HaveCount(2);
			documents.Should().Contain(d => d.DocumentId.Equals(document1.DocumentId));
			documents.Should().Contain(d => d.DocumentId.Equals(document2.DocumentId));
		}
	}
}
