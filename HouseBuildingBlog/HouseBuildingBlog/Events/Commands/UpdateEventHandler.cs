using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, IActionResult>
	{
		public Task<IActionResult> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
