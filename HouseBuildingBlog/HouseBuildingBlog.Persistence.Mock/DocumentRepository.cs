using HouseBuildingBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock
{
	public class DocumentRepository : IDocumentRepository
	{
		private readonly IList<Document> _repo = new List<Document>();

		public Task Delete(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.DocumentId.Equals(id));
			if (tag != null)
				_repo.Remove(tag);

			return Task.CompletedTask;
		}

		public Task<Document> Get(Guid id)
		{
			var tag = _repo.SingleOrDefault(t => t.DocumentId.Equals(id));
			return Task.FromResult(tag);
		}

		public Task<IList<Document>> Query(Func<Document, bool> query)
		{
			var queryResult = _repo.Where(t => query(t));
			IList<Document> result = new List<Document>(queryResult);
			return Task.FromResult(result);
		}

		public Task Save(Document model)
		{
			var tag = _repo.SingleOrDefault(t => t.DocumentId.Equals(model.DocumentId));
			tag = model;
			return Task.CompletedTask;
		}
	}
}
