using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.Mock.Repositories;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class CachedWriteDocumentsRepository : IWriteDocumentsRepository
	{
		public readonly DocumentRepository _repo;

		public CachedWriteDocumentsRepository(DocumentRepository repo)
		{
			_repo = repo;
		}

		public async Task<IDocument> CreateDocumentAsync(IDocument newDocument)
		{
			var docExists = await _repo.GetById(newDocument.DocumentId);
			if (docExists != null)
				throw new InvalidOperationException("Document already exists.");
			else
				await _repo.Save(newDocument);
			return newDocument;
		}

		public async Task<IDocument> DeleteDocumentAsync(Guid documentId)
		{
			var docExists = await _repo.GetById(documentId);
			if (docExists != null)
				await _repo.Delete(documentId);
			return docExists;
		}

		public async Task<IDocument> UpdateDocumentAsync(IDocument document)
		{
			var existingDoc = await _repo.GetById(document.DocumentId);
			if (existingDoc != null)
				await _repo.Save(document);
			return document;
		}
	}
}
