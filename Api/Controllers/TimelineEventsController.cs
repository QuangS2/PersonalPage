using Application.DTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimelineEventsController : ControllerBase
    {
        //service injection for ITimelineEventsService
        private readonly ITimelineEventsService _timelineEventsService;
        public TimelineEventsController(ITimelineEventsService timelineEventsService)
        {
            _timelineEventsService = timelineEventsService;
        }
        //get timeline event by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimelineEventById(int id)
        {
            var timelineEvent = await _timelineEventsService.GetTimelineEventByIdAsync(id);
            if (timelineEvent == null)
            {
                return NotFound();
            }
            return Ok(timelineEvent);
        }
        //delete timeline event by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimelineEvent(int id)
        {
            var result = await _timelineEventsService.DeleteTimelineEventAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        //create timeline event async belong a user
        [HttpPost("{userName}")]
        public async Task<IActionResult> CreateTimelineEvent(string userName, [FromBody] TimelineEventCreateDto timelineEventCreateDto)
        {
            var timelineEvent = await _timelineEventsService.CreateTimelineEventAsync(timelineEventCreateDto, userName);
            if (timelineEvent == null)
            {
                return BadRequest("Timeline event creation failed.");
            }
            return Ok(timelineEvent);
        }
        //update timeline event by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimelineEvent(int id, [FromBody] TimelineEventUpdateDto timelineEventUpdateDto)
        {
            var result = await _timelineEventsService.UpdateTimelineEventAsync(id, timelineEventUpdateDto);
            if (!result)
            {
                return NotFound("Timeline event not found.");
            }
            return Ok("Timeline event updated successfully.");
        }
        //get all timeline events by user name async
        [HttpGet("user/{userName}")]
        public async Task<IActionResult> GetTimelineEventsByUserName(string userName)
        {
            var timelineEvents = await _timelineEventsService.GetTimelineEventsByUserNameAsync(userName);
            return Ok(timelineEvents);
        }
    }

}
