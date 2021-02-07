using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IWriteDocumentsAggregate
	{
		Task<IDocument> CreateDocumentAsync(IDocumentContent newDocumentContent, IEnumerable<Guid> assignedTagIds);

		Task<IDocument> UpdateDocumentAsync(Guid documentId, IDocumentContent documentContent, IEnumerable<Guid> assignedTagIds);

		Task<IDocument> DeleteDocumentAsync(Guid documentId);

		Task<IDocumentFile> UploadFileAsync(Guid documentId, IDocumentFile file);
	}
}
