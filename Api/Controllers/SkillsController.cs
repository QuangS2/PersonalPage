using Application.DTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        //service
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        //create skill
        [HttpPost("user/{username}")]
        public async Task<IActionResult> CreateSkill(string username, [FromBody] SkillCreateDto skillCreateDto)
        {
            var skill = await _skillService.CreateSkillAsync(skillCreateDto, username);
            if (skill == null)
            {
                return BadRequest("Skill creation failed.");
            }
            return Ok(skill);
        }
        //get all skills by username
        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetSkillsByUserName(string username)
        {
            var skills = await _skillService.GetSkillsByUserNameAsync(username);
            return Ok(skills);
        }
        //get skill by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound("Skill not found.");
            }
            return Ok(skill);
        }
        //update skill
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody] SkillUpdateDto skillUpdateDto)
        {
            var result = await _skillService.UpdateSkillAsync(id, skillUpdateDto);
            if (!result)
            {
                return BadRequest("Skill update failed.");
            }
            return Ok("Skill updated successfully.");
        }
        //delete skill
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _skillService.DeleteSkillAsync(id);
            if (!result)
            {
                return BadRequest("Skill deletion failed.");
            }
            return Ok("Skill deleted successfully.");
        }
    }
}
