using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseBuildingBlog.Domain
{
    public class Event
    {
        public Guid EventId { get; private set; }

        public string Title { get; private set; }

        public DateTime Date { get; private set; }

        public IList<IContentBlock> ContentBlocks { get; private set; }

        public IList<Tag> Tags { get; private set; }

        public Event(Guid eventId, string title, DateTime date)
        {
            EventId = eventId;
            Title = title;
            Date = date;
            ContentBlocks = new List<IContentBlock>();
            Tags = new List<Tag>();
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateDate(DateTime date)
        {
            Date = date;
        }

        /*=================== CONTENT ====================*/
        public void AddContentBlock(IContentBlock content)
        {
            ContentBlocks.Add(content);
        }

        public void UpdateContentBlock(Guid contentId, IContentBlock content)
        {
            var contentBlock = ContentBlocks.SingleOrDefault(c => c.ContentId.Equals(contentId));
            ContentBlocks.Remove(contentBlock);
            ContentBlocks.Add(content);
        }

        public void DeleteContentBlock(Guid contentId)
        {
            var contentBlock = ContentBlocks.SingleOrDefault(c => c.ContentId.Equals(contentId));
            ContentBlocks.Remove(contentBlock);
        }
    }
}
