using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.MSSql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class WriteDocumentsAggregate : Domain.Documents.WriteDocumentsAggregate
	{
		private readonly DatabaseContext _DBContext;

		public WriteDocumentsAggregate(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}
		protected override async Task<IDocument> CreateDocument(IDocument newDocument)
		{
			var document = new DocumentModel(newDocument);
			_DBContext.Add(document);
			await _DBContext.SaveChangesAsync();

			return newDocument;
		}

		protected override async Task<IDocument> DeleteDocument(Guid documentId)
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

		protected override async Task<IDocument> UpdateDocument(IDocument document)
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
