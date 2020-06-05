using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Events.Queries
{
	public class GetAllEventsQuery : IRequest<IActionResult>
	{
	}
}
