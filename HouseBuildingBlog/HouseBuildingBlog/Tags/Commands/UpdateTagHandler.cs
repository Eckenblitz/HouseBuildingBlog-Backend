using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, IActionResult>
    {
        public Task<IActionResult> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
