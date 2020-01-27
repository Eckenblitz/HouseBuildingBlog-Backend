using HouseBuildingBlog.Tags.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseBuildingBlog.Tags.Commands
{
    public class CreateTagCommand : IRequest<IActionResult>
    {
        public TagDto Data { get; }

        public CreateTagCommand(TagDto data)
        {
            Data = data;
        }
    }
}
