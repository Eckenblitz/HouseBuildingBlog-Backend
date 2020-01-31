using HouseBuildingBlog.Documents.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Documents.Commands
{
	public class CreateDocumentCommand : IRequest<IActionResult>
	{
		public DocumentCommandDto Data { get; }

		public CreateDocumentCommand(DocumentCommandDto data)
		{
			this.Data = data;
		}
	}
}
