using HouseBuildingBlog.Api.Documents.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Api.Documents.Commands
{
	public class CreateDocumentCommand : IRequest<IActionResult>
	{
		public DocumentCommandDto Data { get; }

		public CreateDocumentCommand(DocumentCommandDto data)
		{
			Data = data;

		}

	}
}
