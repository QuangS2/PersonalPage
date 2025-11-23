using Application.DTOs;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        //service
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        //get project by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound("Project not found.");
            }
            return Ok(project);
        }
        //get all projects by username
        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetProjectsByUserName(string username)
        {
            var projects = await _projectService.GetProjectsByUserNameAsync(username);
            return Ok(projects);
        }
        //create project
        [HttpPost("user/{username}")]
        public async Task<IActionResult> CreateProject(string username, [FromBody] ProjectCreateDto projectCreateDto)
        {
            var project = await _projectService.CreateProjectAsync(projectCreateDto, username);
            if (project == null)
            {
                return BadRequest("Project creation failed.");
            }
            return Ok(project);
        }
        //delete project
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            if (!result)
            {
                return NotFound("Project not found.");
            }
            return Ok("Project deleted successfully.");
        }
        //update project
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            var result = await _projectService.UpdateProjectAsync(id, projectUpdateDto);
            if (!result)
            {
                return BadRequest("Project update failed.");
            }
            return Ok("Project updated successfully.");
        }
        //add category to project
        [HttpPost("{projectId}/category/{categoryId}")]
        public async Task<IActionResult> AddCategoryToProject(int projectId, int categoryId)
        {
            var result = await _projectService.AddCategoryToProjectAsync(projectId, categoryId);
            if (!result)
            {
                return BadRequest("Adding category to project failed.");
            }
            return Ok("Category added to project successfully.");
        }
        //remove category from project
        [HttpDelete("{projectId}/category/{categoryId}")]
        public async Task<IActionResult> RemoveCategoryFromProject(int projectId, int categoryId)
        {
            var result = await _projectService.RemoveCategoryFromProjectAsync(projectId, categoryId);
            if (!result)
            {
                return BadRequest("Removing category from project failed.");
            }
            return Ok("Category removed from project successfully.");
        }
        //add technology to project
        [HttpPost("{projectId}/technology/{technologyId}")]
        public async Task<IActionResult> AddTechnologyToProject(int projectId, int technologyId)
        {
            var result = await _projectService.AddTechnologyToProjectAsync(projectId, technologyId);
            if (!result)
            {
                return BadRequest("Adding technology to project failed.");
            }
            return Ok("Technology added to project successfully.");
        }
        //remove technology from project
        [HttpDelete("{projectId}/technology/{technologyId}")]
        public async Task<IActionResult> RemoveTechnologyFromProject(int projectId, int technologyId)
        {
            var result = await _projectService.RemoveTechnologyFromProjectAsync(projectId, technologyId);
            if (!result)
            {
                return BadRequest("Removing technology from project failed.");
            }
            return Ok("Technology removed from project successfully.");
        }
    }
}
