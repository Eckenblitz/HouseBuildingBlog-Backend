using HouseBuildingBlog.Tags.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Tags.Commands
{
    public class CreateTagCommand : IRequest<IActionResult>
    {
        public TagCommandDto Data { get; }

        public CreateTagCommand(TagCommandDto data)
        {
            Data = data;
        }
    }
}
