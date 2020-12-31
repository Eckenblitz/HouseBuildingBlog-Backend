using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public abstract class ReadDocumentsAggregateBase : IReadDocumentsAggregate
	{
		protected abstract Task<IEnumerable<IDocument>> GetAll();
		public Task<IEnumerable<IDocument>> GetAllAsync()
		{
			return GetAll();
		}

		protected abstract Task<IDocument> Get(Guid id);
		public Task<IDocument> GetAsync(Guid id)
		{
			return Get(id);
		}
	}
}
