using HouseBuildingBlog.Domain.Errors;
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

		public async Task<IDocument> GetByIdAsync(Guid documentId)
		{
			var existingDocument = await _readDocumentsRepository.GetByIdAsync(documentId);

			if (existingDocument == null)
				throw new AggregateNotFoundException(DocumentErrorCodes.DocumentNotFound, documentId);

			return existingDocument;
		}
	}
}
