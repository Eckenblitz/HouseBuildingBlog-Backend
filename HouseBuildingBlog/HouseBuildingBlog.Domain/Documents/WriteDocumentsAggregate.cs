using HouseBuildingBlog.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public class WriteDocumentsAggregate : IWriteDocumentsAggregate
	{
		private readonly IWriteDocumentsRepository _writeDocumentsRepository;

		public WriteDocumentsAggregate(IWriteDocumentsRepository writeDocumentsRepository)
		{
			_writeDocumentsRepository = writeDocumentsRepository;
		}

		public async Task<IDocument> CreateDocumentAsync(IDocumentContent newDocumentContent, IEnumerable<Guid> assignedTagIds)
		{
			var newDocument = new Document(Guid.NewGuid(), newDocumentContent, assignedTagIds);

			var validationErrors = DocumentValidator.Validate(newDocument);
			if (validationErrors.Count > 0)
				throw new ValidationException(validationErrors);

			return await _writeDocumentsRepository.CreateDocumentAsync(newDocument);
		}

		public async Task<IDocument> UpdateDocumentAsync(Guid documentId, IDocumentContent documentContent, IEnumerable<Guid> assignedTagIds)
		{
			var existingDocument = await CheckExistingDocumentAndThrow(documentId);

			var document = new Document(documentId, existingDocument, assignedTagIds);
			document.Update(documentContent);

			var validationErrors = DocumentValidator.Validate(document);
			if (validationErrors.Count > 0)
				throw new ValidationException(validationErrors);

			return await _writeDocumentsRepository.UpdateDocumentAsync(document);
		}

		public async Task<IDocument> DeleteDocumentAsync(Guid documentId)
		{
			_ = await CheckExistingDocumentAndThrow(documentId);
			return await _writeDocumentsRepository.DeleteDocumentAsync(documentId);
		}

		public async Task<IDocumentFile> UploadFileAsync(Guid documentId, IDocumentFile file)
		{
			var validationErrors = DocumentFileValidator.Validate(file);
			if (validationErrors.Count > 0)
				throw new ValidationException(validationErrors);

			_ = await CheckExistingDocumentAndThrow(documentId);
			return await _writeDocumentsRepository.UploadFileAsync(documentId, file);
		}

		private async Task<IDocument> CheckExistingDocumentAndThrow(Guid documentId)
		{
			var existingDocument = await _writeDocumentsRepository.GetByIdAsync(documentId);

			if (existingDocument == null)
				throw new AggregateNotFoundException(DocumentErrorCodes.DocumentNotFound, documentId);

			return existingDocument;
		}
	}
}
