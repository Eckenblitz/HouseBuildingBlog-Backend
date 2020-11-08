using HouseBuildingBlog.Domain.Documents;
using HouseBuildingBlog.Persistence.Mock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.Mock.Repositories
{
	public class DocumentRepository
	{
		private readonly IList<DocumentModelMock> _repo = new List<DocumentModelMock>();

		public Task Delete(Guid documentId)
		{
			var doc = _repo.SingleOrDefault(doc => doc.DocumentId.Equals(documentId));
			if (doc != null)
				_repo.Remove(doc);

			return Task.CompletedTask;
		}

		public Task Save(IDocument document)
		{
			var doc = _repo.SingleOrDefault(doc => doc.DocumentId.Equals(document.DocumentId));
			if (doc != null)
				doc.Update(document);
			else
				_repo.Add(new DocumentModelMock(document));

			return Task.CompletedTask;
		}

		public Task<DocumentModelMock> GetById(Guid id)
		{
			DocumentModelMock doc = _repo.SingleOrDefault(doc => doc.DocumentId.Equals(id));
			return Task.FromResult(doc);
		}

		public Task<IList<DocumentModelMock>> Query(Func<IDocument, bool> query)
		{
			var searchResult = _repo.Where(t => query(t));
			IList<DocumentModelMock> documentList = new List<DocumentModelMock>(searchResult);
			return Task.FromResult(documentList);
		}
	}
}
