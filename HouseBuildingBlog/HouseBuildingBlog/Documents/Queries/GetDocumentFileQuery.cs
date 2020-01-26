using HouseBuildingBlog.Documents.Queries.Contracts;
using MediatR;
using System;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentFileQuery : IRequest<DocumentFileDto>
	{
		public Guid Id { get; }

		public GetDocumentFileQuery(Guid id)
		{
			Id = id;
		}
	}
}
