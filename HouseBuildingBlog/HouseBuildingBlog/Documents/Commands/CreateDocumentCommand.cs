using HouseBuildingBlog.Documents.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Documents.Commands
{
	public class CreateDocumentCommand : IRequest<IActionResult>
	{
		public DocumentDto Data { get; }

		public CreateDocumentCommand(DocumentDto data)
		{
			this.Data = data;
		}
	}
}
