using System;

namespace HouseBuildingBlog.Events.Commands.Contracts
{
    public class EventCommandDto
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        //public IList<Content> ContentSection { get; internal set; }
    }
}
