using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.MSSql.Files;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class ReadDocumentsRepository : IReadDocumentsRepository
	{
		private readonly DatabaseContext _DBContext;
		private readonly IReadFileRepository<IDocumentFile> _readFileRepository;

		public ReadDocumentsRepository(DatabaseContext dBContext, IReadFileRepository<IDocumentFile> readFileRepository)
		{
			_DBContext = dBContext;
			_readFileRepository = readFileRepository;
		}
		public async Task<IDocument> GetByIdAsync(Guid id)
		{
			return await _DBContext.Documents
				.Include(d => d.AssignedTags)
				.SingleOrDefaultAsync(d => d.DocumentId == id);
		}

		public async Task<IEnumerable<IDocument>> GetAllAsync()
		{
			return await _DBContext.Documents
				.Include(d => d.AssignedTags)
				.ToListAsync();
		}

		public async Task<IDocumentFile> GetFileAsync(Guid documentId)
		{
			var documentFile = await _DBContext.DocumentFiles.FindAsync(documentId);
			if (documentFile == null)
				return null;

			documentFile.Binaries = await _readFileRepository.ReadFileBinariesAsync(documentFile);

			return documentFile;
		}
	}
}
