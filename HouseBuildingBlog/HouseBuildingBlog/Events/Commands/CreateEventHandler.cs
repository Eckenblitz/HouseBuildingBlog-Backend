using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class CreateEventHandler : IRequestHandler<CreateEventCommand, IActionResult>
	{
		public Task<IActionResult> Handle(CreateEventCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
