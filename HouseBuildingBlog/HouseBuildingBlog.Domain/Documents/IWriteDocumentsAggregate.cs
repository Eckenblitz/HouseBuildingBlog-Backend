using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IWriteDocumentsAggregate
	{
		Task<IDocument> CreateDocumentAsync(IDocumentContent newDocumentContent);

		Task<IDocument> UpdateDocumentAsync(Guid documentId, IDocumentContent documentContent);

		Task<IDocument> DeleteDocumentAsync(Guid documentId);

		Task<IDocumentFile> UploadFileAsync(Guid documentId, IDocumentFile file);
	}
}
