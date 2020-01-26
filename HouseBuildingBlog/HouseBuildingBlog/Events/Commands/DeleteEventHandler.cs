using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Events.Commands
{
	public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, IActionResult>
	{
		public Task<IActionResult> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
