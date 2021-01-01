using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.MSSql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class WriteDocumentsRepository : IWriteDocumentsRepository
	{
		private readonly DatabaseContext _DBContext;

		public WriteDocumentsRepository(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}

		public async Task<IDocument> GetByIdAsync(Guid documentId)
		{
			return await _DBContext.Documents
				.SingleOrDefaultAsync(e => e.DocumentId.Equals(documentId));
		}

		public async Task<IDocument> CreateDocumentAsync(IDocument newDocument)
		{
			var document = new DocumentModel(newDocument);
			_DBContext.Add(document);
			await _DBContext.SaveChangesAsync();

			return document;
		}

		public async Task<IDocument> DeleteDocumentAsync(Guid documentId)
		{
			var document = await _DBContext.Documents
				.SingleOrDefaultAsync(e => e.DocumentId.Equals(documentId));
			if (document != null)
			{
				_DBContext.Remove(document);
				await _DBContext.SaveChangesAsync();
			}
			return document;
		}

		public async Task<IDocument> UpdateDocumentAsync(IDocument document)
		{
			var toUpdate = await _DBContext.Documents
				.SingleOrDefaultAsync(e => e.DocumentId.Equals(document.DocumentId));
			if (toUpdate != null)
			{
				toUpdate.Update(document);
				_DBContext.Documents.Update(toUpdate);
				await _DBContext.SaveChangesAsync();
			}
			return toUpdate;
		}
	}
}
