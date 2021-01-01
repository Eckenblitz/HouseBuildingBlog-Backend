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
			var existingDocument = await _writeDocumentsRepository.GetByIdAsync(documentId);

			if (existingDocument == null)
				throw new AggregateNotFoundException(DocumentErrorCodes.DocumentNotFound, documentId);

			var document = new Document(documentId, existingDocument);
			document.Update(documentContent);

			var validationError = DocumentValidator.Validate(document);
			if (validationError.Count > 0)
				throw new ValidationException(validationError);

			return await _writeDocumentsRepository.UpdateDocumentAsync(document);
		}

		public async Task<IDocument> DeleteDocumentAsync(Guid documentId)
		{
			var existingDocument = await _writeDocumentsRepository.GetByIdAsync(documentId);

			if (existingDocument == null)
				throw new AggregateNotFoundException(DocumentErrorCodes.DocumentNotFound, documentId);

			return await _writeDocumentsRepository.DeleteDocumentAsync(documentId);
		}
	}
}
