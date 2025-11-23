using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TimelineEventsRepository : ITimelineEventsRepository
    {
        //db context injection
        private readonly ApplicationDbContext _context;
        public TimelineEventsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TimelineEvents> CreateTimelineEventAsync(TimelineEvents timelineEvent)
        {
            _context.TimelineEvents.Add(timelineEvent);
            await  _context.SaveChangesAsync();
            return timelineEvent;
        }

        public async Task DeleteTimelineEventAsync(TimelineEvents timelineEvent)
        {
            _context.TimelineEvents.Remove(timelineEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<TimelineEvents?> GetTimelineEventByIdAsync(int id)
        {
            return await _context.TimelineEvents.FindAsync(id);
        }

        public async Task<IEnumerable<TimelineEvents>> GetTimelineEventsByUserIdAsync(string userId)
        { 
            return _context.TimelineEvents.Where(te => te.UserId == userId).ToList();
        }

        public async Task<IEnumerable<TimelineEvents>> GetTimelineEventsByUserNameAsync(string userName)
        {
            return _context.TimelineEvents.Where(te => te.User.UserName == userName).ToList();
        }

        public async Task<TimelineEvents> UpdateTimelineEventAsync(TimelineEvents timelineEvent)
        {
            _context.TimelineEvents.Update(timelineEvent);
            await _context.SaveChangesAsync();
            return timelineEvent;
        }
    }
}
