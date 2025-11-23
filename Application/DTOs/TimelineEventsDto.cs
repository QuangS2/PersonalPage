using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TimelineEventsDto
    {
        // user id, event type, title, organization, start date, end date, description
        public string EventType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }
    //create timeline event request object
    public class TimelineEventCreateDto
    {
        public string EventType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
    //update timeline event request object
    public class TimelineEventUpdateDto
    {
        public string? EventType { get; set; }
        public string? Title { get; set; }
        public string? Organization { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
    }
}
