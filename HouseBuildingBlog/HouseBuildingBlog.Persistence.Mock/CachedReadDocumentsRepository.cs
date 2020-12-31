using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	class CachedReadDocumentsRepository : IReadDocumentsRepository
	{
		public readonly DocumentRepository _repo;

		public CachedReadDocumentsRepository(DocumentRepository repo)
		{
			_repo = repo;
		}

		public async Task<IDocument> GetAsync(Guid id)
		{
			return await _repo.GetById(id);
		}

		public async Task<IEnumerable<IDocument>> GetAllAsync()
		{
			return await _repo.Query(e => true);
		}
	}
}
