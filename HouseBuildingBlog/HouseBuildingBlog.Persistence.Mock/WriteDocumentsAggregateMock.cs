using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.Mock.Repositories;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class WriteDocumentsAggregateMock : WriteDocumentsAggregateBase
	{
		public readonly DocumentRepository _repo;

		public WriteDocumentsAggregateMock(DocumentRepository repo)
		{
			_repo = repo;
		}

		protected override async Task<IDocument> CreateDocument(IDocument newDocument)
		{
			var docExists = await _repo.GetById(newDocument.DocumentId);
			if (docExists != null)
				throw new InvalidOperationException("Document already exists.");
			else
				await _repo.Save(newDocument);
			return newDocument;
		}

		protected override async Task<IDocument> DeleteDocument(Guid documentId)
		{
			var docExists = await _repo.GetById(documentId);
			if (docExists != null)
				await _repo.Delete(documentId);
			return docExists;
		}

		protected override async Task<IDocument> UpdateDocument(IDocument document)
		{
			var existingDoc = await _repo.GetById(document.DocumentId);
			if (existingDoc != null)
				await _repo.Save(document);
			return document;
		}

		protected override async Task<IDocument> UpdateFile(Guid documentId, IFile file)
		{
			var existingDocument = await _repo.GetById(documentId);
			if (existingDocument != null)
			{
				existingDocument.UpdateFile(file);
				await _repo.Save(existingDocument);
			}
			return existingDocument;
		}
	}
}
