using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public interface IReadDocumentsRepository
	{
		Task<IEnumerable<IDocument>> GetAllAsync();

		Task<IDocument> GetByIdAsync(Guid id);
	}
}
