using Application.DTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        //service
        private readonly ITechnologyService _technologyService;
        public TechnologiesController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }
        //get technology by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnologyById(int id)
        {
            var technology = await _technologyService.GetTechnologyByIdAsync(id);
            if (technology == null)
            {
                return NotFound("Technology not found.");
            }
            return Ok(technology);
        }
        //create technology
        [HttpPost]
        public async Task<IActionResult> CreateTechnology([FromBody] TechnologyCreateDto technologyCreateDto)
        {
            var technology = await _technologyService.CreateTechnologyAsync(technologyCreateDto);
            if (technology == null)
            {
                return BadRequest("Technology creation failed.");
            }
            return Ok(technology);
        }
        //delete technology by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnology(int id)
        {
            var result = await _technologyService.DeleteTechnologyAsync(id);
            if (!result)
            {
                return NotFound("Technology not found.");
            }
            return Ok("Technology deleted successfully.");
        }
        //update technology by id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnology(int id, [FromBody] TechnologyUpdateDto technologyUpdateDto)
        {
            var result = await _technologyService.UpdateTechnologyAsync(id, technologyUpdateDto);
            if (!result)
            {
                return NotFound("Technology not found.");
            }
            return Ok("Technology updated successfully.");
        }

    }
}
