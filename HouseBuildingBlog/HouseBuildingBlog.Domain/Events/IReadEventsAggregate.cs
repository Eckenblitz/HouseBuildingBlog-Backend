using HouseBuildingBlog.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Events
{
	public interface IReadEventsAggregate
	{
		Task<IEvent> GetAsync(Guid eventId);

		Task<IEnumerable<IEvent>> GetAllAsync();

		Task<IEnumerable<IEvent>> FilterByTags(IEnumerable<Guid> tagIds);

		Task<IEnumerable<IDocument>> GetAssignedDocumentsAsync(Guid eventId);
	}
}
