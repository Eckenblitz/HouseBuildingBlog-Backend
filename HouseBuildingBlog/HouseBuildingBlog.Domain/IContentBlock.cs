using System;

namespace HouseBuildingBlog.Domain
{
    public interface IContentBlock
    {
        Guid ContentId { get; }

        ContentType Type { get; }

        int Position { get; }
    }
}