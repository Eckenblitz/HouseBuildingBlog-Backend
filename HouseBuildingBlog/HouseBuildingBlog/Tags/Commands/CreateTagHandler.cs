using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, IActionResult>
    {
        public Task<IActionResult> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
