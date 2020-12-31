using HouseBuildingBlog.Domain.Validation;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public abstract class WriteDocumentsAggregate : IWriteDocumentsAggregate
	{
		private readonly IWriteDocumentsRepository _writeDocumentsRepository;

		protected WriteDocumentsAggregate(IWriteDocumentsRepository writeDocumentsRepository)
		{
			_writeDocumentsRepository = writeDocumentsRepository;
		}

		public async Task<IDocument> CreateDocumentAsync(IDocument newDocument)
		{
			var validationError = DocumentValidator.Validate(newDocument);
			if (validationError.Count > 0)
				throw new ValidationException(validationError);

			return await _writeDocumentsRepository.CreateDocumentAsync(newDocument);
		}

		public async Task<IDocument> DeleteDocumentAsync(Guid documentId)
		{
			return await _writeDocumentsRepository.DeleteDocumentAsync(documentId);
		}

		public async Task<IDocument> UpdateDocumentAsync(IDocument document)
		{
			var validationError = DocumentValidator.Validate(document);
			if (validationError.Count > 0)
				throw new ValidationException(validationError);

			return await _writeDocumentsRepository.UpdateDocumentAsync(document);
		}
	}
}
