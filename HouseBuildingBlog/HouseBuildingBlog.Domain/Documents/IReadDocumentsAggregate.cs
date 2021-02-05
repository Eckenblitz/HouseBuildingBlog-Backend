using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IReadDocumentsAggregate
	{
		Task<IEnumerable<IDocument>> GetAllAsync();

		Task<IDocument> GetByIdAsync(Guid documentId);

		Task<IDocumentFile> DownloadFileAsync(Guid documentId);
	}
}
