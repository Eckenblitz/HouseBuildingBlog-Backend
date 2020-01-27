using System;

namespace HouseBuildingBlog.Events.Commands.Contracts
{
    public class EventDto
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        //public IList<Content> ContentSection { get; internal set; }
    }
}
