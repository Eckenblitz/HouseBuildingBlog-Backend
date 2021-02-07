using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using HouseBuildingBlog.Domain.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class CreateDocumentCommand : IRequest<IActionResult>, IDocumentContent
	{
		public string Title { get; }

		public string Comment { get; }

		public decimal? Price { get; }

		public Guid? EventId { get; }

		public IList<Guid> TagIds { get; }

		public CreateDocumentCommand(DocumentCommandDto data)
		{
			Title = data.Title;
			Comment = data.Comment;
			Price = data.Price;
			EventId = data.EventId;
			TagIds = data.TagIds;
		}
	}
}
