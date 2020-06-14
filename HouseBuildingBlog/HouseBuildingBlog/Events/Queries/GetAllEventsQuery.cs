using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Api.Events.Queries
{
	public class GetAllEventsQuery : IRequest<IActionResult>
	{
	}
}
