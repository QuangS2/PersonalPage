using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TimelineEvents : BaseEntity
    {
        // user id, event type, title, organization, start date, end date, description

        public string EventType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        //timeline event belong a user
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;

    }
}
