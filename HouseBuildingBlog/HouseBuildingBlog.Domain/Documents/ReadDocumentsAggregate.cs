using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Domain.Documents
{
	public class ReadDocumentsAggregate : IReadDocumentsAggregate
	{
		private readonly IReadDocumentsRepository _readDocumentsRepository;

		public ReadDocumentsAggregate(IReadDocumentsRepository readDocumentsRepository)
		{
			_readDocumentsRepository = readDocumentsRepository;
		}

		public async Task<IEnumerable<IDocument>> GetAllAsync()
		{
			return await _readDocumentsRepository.GetAllAsync();
		}

		public async Task<IDocument> GetAsync(Guid id)
		{
			return await _readDocumentsRepository.GetAsync(id);
		}
	}
}
