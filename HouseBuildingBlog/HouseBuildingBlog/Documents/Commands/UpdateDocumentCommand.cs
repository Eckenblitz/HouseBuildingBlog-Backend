using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using HouseBuildingBlog.Domain.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class UpdateDocumentCommand : IRequest<IActionResult>, IDocumentContent
	{
		public Guid DocumentId { get; }

		public string Title { get; }

		public string Comment { get; }

		public decimal? Price { get; }

		public Guid? EventId { get; }

		public IEnumerable<Guid> TagIds { get; }

		public UpdateDocumentCommand(Guid documentId, DocumentCommandDto data)
		{
			DocumentId = documentId;
			Title = data.Title;
			Comment = data.Comment;
			Price = data.Price;
			EventId = data.EventId;
			TagIds = data.TagIds;
		}
	}
}
