using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TimelineEventsService : ITimelineEventsService
    {
        //repository injection
        private readonly ITimelineEventsRepository _timelineEventsRepository;
        private readonly IUserRepository _userRepository;
        //mapper injection
        private readonly IMapper _mapper;
        public TimelineEventsService(ITimelineEventsRepository timelineEventsRepository, IMapper mapper, IUserRepository userRepository)
        {
            _timelineEventsRepository = timelineEventsRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<TimelineEventsDto> CreateTimelineEventAsync(TimelineEventCreateDto timelineEventCreateDto, string userName)
        {
            //get user by username
            var user = await _userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            //map dto to entity
            var timelineEvent = _mapper.Map<Domain.Entities.TimelineEvents>(timelineEventCreateDto);
            timelineEvent.UserId = user.Id;
            //create timeline event
            var createdTimelineEvent = await _timelineEventsRepository.CreateTimelineEventAsync(timelineEvent);
            //map entity to dto
            var timelineEventDto = _mapper.Map<TimelineEventsDto>(createdTimelineEvent);
            return timelineEventDto;
        }

        public async Task<bool> DeleteTimelineEventAsync(int id)
        {
            //get existing timeline event
            var existingTimelineEvent = await _timelineEventsRepository.GetTimelineEventByIdAsync(id);
            if (existingTimelineEvent == null)
            {
                return false; // Timeline event not found
            }
            //delete timeline event
            await _timelineEventsRepository.DeleteTimelineEventAsync(existingTimelineEvent);
            return true;
        }

        public async Task<TimelineEventsDto?> GetTimelineEventByIdAsync(int id)
        {
            //get timeline event by id
            var timelineEvent = await _timelineEventsRepository.GetTimelineEventByIdAsync(id);
            if (timelineEvent == null)
            {
                return null;
            }
            //map to dto
            var timelineEventDto = _mapper.Map<TimelineEventsDto>(timelineEvent);
            return timelineEventDto;
        }

        public async Task<IEnumerable<TimelineEventsDto>> GetTimelineEventsByUserNameAsync(string userName)
        {
            //get user by username
            var user = await _userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return Enumerable.Empty<TimelineEventsDto>();
            }
            //get timeline events by user id
            var timelineEvents = await _timelineEventsRepository.GetTimelineEventsByUserNameAsync(userName);
            //map to dto
            var timelineEventsDtos = _mapper.Map<IEnumerable<TimelineEventsDto>>(timelineEvents);
            return timelineEventsDtos;
        }

        public async Task<bool> UpdateTimelineEventAsync(int id, TimelineEventUpdateDto timelineEventUpdateDto)
        {
            //get existing timeline event
            var existingTimelineEvent = await _timelineEventsRepository.GetTimelineEventByIdAsync(id);
            if (existingTimelineEvent == null)
            {
                return false; // Timeline event not found
            }
            //map update dto to existing entity
            _mapper.Map(timelineEventUpdateDto, existingTimelineEvent);
            //update timeline event
            await _timelineEventsRepository.UpdateTimelineEventAsync(existingTimelineEvent);
            return true;
        }
    }
}
