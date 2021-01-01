using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IWriteDocumentsRepository
	{
		Task<IDocument> GetByIdAsync(Guid documentId);
		Task<IDocument> CreateDocumentAsync(IDocument document);
		Task<IDocument> UpdateDocumentAsync(IDocument document);
		Task<IDocument> DeleteDocumentAsync(Guid documentId);
	}
}
