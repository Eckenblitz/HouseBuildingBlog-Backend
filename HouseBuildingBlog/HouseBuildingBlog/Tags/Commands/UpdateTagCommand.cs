using HouseBuildingBlog.Tags.Commands.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HouseBuildingBlog.Tags.Commands
{
    public class UpdateTagCommand : IRequest<IActionResult>
    {
        public Guid TagId { get; }
        public TagCommandDto Data { get; }

        public UpdateTagCommand(Guid tagId, TagCommandDto data)
        {
            TagId = tagId;
            Data = data;
        }
    }
}
