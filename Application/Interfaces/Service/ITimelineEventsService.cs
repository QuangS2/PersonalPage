using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface ITimelineEventsService
    {
        //timeline event belong a user
        //create timeline event async belong a user
        Task<TimelineEventsDto> CreateTimelineEventAsync(TimelineEventCreateDto timelineEventCreateDto, string userName);
        //get timeline event by id async
        Task<TimelineEventsDto?> GetTimelineEventByIdAsync(int id);
        //get all timeline events by user name async
        Task<IEnumerable<TimelineEventsDto>> GetTimelineEventsByUserNameAsync(string userName);
        //update timeline event async
        Task<bool> UpdateTimelineEventAsync(int id, TimelineEventUpdateDto timelineEventUpdateDto);
        //delete timeline event async
        Task<bool> DeleteTimelineEventAsync(int id);

    }
}
