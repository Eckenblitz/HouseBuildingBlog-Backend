using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Api.Documents.Queries
{
	public class GetAllDocumentsQuery : IRequest<IActionResult>
	{ }
}
