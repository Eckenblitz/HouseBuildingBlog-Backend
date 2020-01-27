using HouseBuildingBlog.Tags.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Tags.Commands
{
    public class UpdateTagCommand : IRequest<IActionResult>
    {
        public Guid TagId { get; }
        public TagDto Data { get; }

        public UpdateTagCommand(Guid tagId, TagDto data)
        {
            TagId = tagId;
            Data = data;
        }
    }
}
