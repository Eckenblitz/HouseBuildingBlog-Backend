using HouseBuildingBlog.Domain.Validation;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public abstract class WriteDocumentsAggregateBase : IWriteDocumentsAggregate
	{

		protected abstract Task<IDocument> CreateDocument(IDocument newDocument);
		public Task<IDocument> CreateDocumentAsync(IDocument newDocument)
		{
			var validationError = DocumentValidator.Validate(newDocument);
			if (validationError.Count > 0)
				throw new ValidationException(validationError);

			return CreateDocument(newDocument);
		}

		protected abstract Task<IDocument> DeleteDocument(Guid documentId);

		public Task<IDocument> DeleteDocumentAsync(Guid documentId)
		{
			return DeleteDocument(documentId);
		}

		protected abstract Task<IDocument> UpdateDocument(IDocument document);
		public Task<IDocument> UpdateDocumentAsync(IDocument document)
		{
			var validationError = DocumentValidator.Validate(document);
			if (validationError.Count > 0)
				throw new ValidationException(validationError);
			return UpdateDocument(document);
		}
	}
}
