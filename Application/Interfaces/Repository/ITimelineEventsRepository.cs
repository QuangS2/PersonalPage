using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Interfaces.Repository
{
    public interface ITimelineEventsRepository
    {
        //create
        Task<TimelineEvents> CreateTimelineEventAsync(TimelineEvents timelineEvent);
        //get
        Task<TimelineEvents?> GetTimelineEventByIdAsync(int id);
        //update
        Task<TimelineEvents> UpdateTimelineEventAsync(TimelineEvents timelineEvent);
        //delete
        Task DeleteTimelineEventAsync(TimelineEvents timelineEvent);
        //get timeline events by username
        Task<IEnumerable<TimelineEvents>> GetTimelineEventsByUserNameAsync(string userName);
        
    }
}
