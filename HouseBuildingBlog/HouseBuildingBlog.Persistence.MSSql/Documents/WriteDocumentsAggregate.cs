using HouseBuildingBlog.Domain.Documents;
using System;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Persistence.MSSql.Documents
{
	class WriteDocumentsAggregate : WriteDocumentsAggregateBase
	{
		protected override Task<IDocument> CreateDocument(IDocument newDocument)
		{
			throw new NotImplementedException();
		}

		protected override Task<IDocument> DeleteDocument(Guid documentId)
		{
			throw new NotImplementedException();
		}

		protected override Task<IDocument> UpdateDocument(IDocument document)
		{
			throw new NotImplementedException();
		}
	}
}
