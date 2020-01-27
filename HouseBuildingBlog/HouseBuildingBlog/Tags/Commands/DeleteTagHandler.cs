using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuildingBlog.Tags.Commands
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, IActionResult>
    {
        public Task<IActionResult> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
