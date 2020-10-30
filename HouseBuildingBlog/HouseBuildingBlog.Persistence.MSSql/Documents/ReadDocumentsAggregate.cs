using HouseBuildingBlog.Domain.Documents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	public class ReadDocumentsAggregate : ReadDocumentsAggregateBase
	{
		private readonly DatabaseContext _DBContext;

		public ReadDocumentsAggregate(DatabaseContext dBContext)
		{
			_DBContext = dBContext;
		}
		protected override async Task<IDocument> Get(Guid id)
		{
			return await _DBContext.Documents
				.SingleOrDefaultAsync(e => e.DocumentId.Equals(id));
		}

		protected override async Task<IEnumerable<IDocument>> GetAll()
		{
			return await _DBContext.Documents
				.ToListAsync();
		}

		protected override async Task<IEnumerable<IDocument>> GetByEventId(Guid eventId)
		{
			return await _DBContext.Documents
				.Where(e => e.EventId.Equals(eventId))
				.ToListAsync();
		}
	}
}
