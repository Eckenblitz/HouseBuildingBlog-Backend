using System;

namespace HouseBuildingBlog.Domain
{
    public class Tag
    {
        public Guid TagId { get; private set; }

        public string Title { get; private set; }

        public Tag(Guid tagId, string title)
        {
            TagId = tagId;
            Title = title;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }
}