using HouseBuildingBlog.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	class ReadDocumentsAggregate : ReadDocumentsAggregateBase
	{
		protected override Task<IDocument> Get(Guid id)
		{
			throw new NotImplementedException();
		}

		protected override Task<IEnumerable<IDocument>> GetAll()
		{
			throw new NotImplementedException();
		}

		protected override Task<IEnumerable<IDocument>> GetByEventId(Guid eventId)
		{
			throw new NotImplementedException();
		}
	}
}
