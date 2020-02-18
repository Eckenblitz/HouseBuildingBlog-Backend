using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Documents.Queries
{
	public class GetDocumentsQuery : IRequest<IActionResult>
	{
	}
}
