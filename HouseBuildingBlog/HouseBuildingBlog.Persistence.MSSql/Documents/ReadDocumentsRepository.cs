using HouseBuildingBlog.Domain.Documents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class ReadDocumentsRepository : IReadDocumentsRepository
	{
		private readonly DatabaseContext _DBContext;

		public ReadDocumentsRepository(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}
		public async Task<IDocument> GetByIdAsync(Guid id)
		{
			return await _DBContext.Documents
				.SingleOrDefaultAsync(e => e.DocumentId.Equals(id));
		}

		public async Task<IEnumerable<IDocument>> GetAllAsync()
		{
			return await _DBContext.Documents
				.ToListAsync();
		}

		public Task<IDocumentFile> GetFileAsync(Guid documentId)
		{
			throw new NotImplementedException();
		}
	}
}
