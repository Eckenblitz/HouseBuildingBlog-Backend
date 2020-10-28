using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	class ReadDocumentsAggregateMock : ReadDocumentsAggregateBase
	{
		public readonly DocumentRepository _repo;

		public ReadDocumentsAggregateMock(DocumentRepository repo)
		{
			_repo = repo;
		}

		protected override async Task<IDocument> Get(Guid id)
		{
			return await _repo.GetById(id);
		}

		protected override async Task<IEnumerable<IDocument>> GetAll()
		{
			return await _repo.Query(e => true);
		}

		protected override async Task<IEnumerable<IDocument>> GetByEventId(Guid eventId)
		{
			return await _repo.Query(d => d.EventId.Equals(eventId));
		}
	}
}
