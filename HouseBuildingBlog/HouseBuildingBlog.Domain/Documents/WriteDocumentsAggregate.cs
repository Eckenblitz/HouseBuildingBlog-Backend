using HouseBuildingBlog.Domain.Errors;
using System;
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

		public async Task<IDocument> CreateDocumentAsync(IDocumentContent newDocumentContent)
		{
			var newDocument = new Document(Guid.NewGuid(), newDocumentContent);

			var validationErrors = DocumentValidator.Validate(newDocument);
			if (validationErrors.Count > 0)
				throw new ValidationException(validationErrors);

			return await _writeDocumentsRepository.CreateDocumentAsync(newDocument);
		}

		public async Task<IDocument> UpdateDocumentAsync(Guid documentId, IDocumentContent documentContent)
		{
			var existingDocument = await CheckExistingDocumentAndThrow(documentId);

			var document = new Document(documentId, existingDocument);
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
