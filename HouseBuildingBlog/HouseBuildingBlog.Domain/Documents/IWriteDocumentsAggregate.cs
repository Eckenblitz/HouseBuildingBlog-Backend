﻿using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IWriteDocumentsAggregate
	{
		Task<IDocument> CreateDocumentAsync(IDocument newDocument);
		Task<IDocument> UpdateDocumentAsync(IDocument document);
		Task<IDocument> DeleteDocumentAsync(Guid documentId);
	}
}