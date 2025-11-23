using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface IProjectService
    {
        //Get All Projects  by UserName
        Task<IEnumerable<ProjectDto>> GetProjectsByUserNameAsync(string userName);
        //Get Project By Id
        Task<ProjectDto?> GetProjectByIdAsync(int id);
        //Create Project by UserName
        Task<ProjectDto> CreateProjectAsync(ProjectCreateDto projectCreateDto, string userName);
        //Update Project
        Task<bool> UpdateProjectAsync(int id, ProjectUpdateDto projectUpdateDto);
        //Delete Project
        Task<bool> DeleteProjectAsync(int id);
        //Add Category To Project Async
        Task<bool> AddCategoryToProjectAsync(int projectId, int categoryId);
        //RemoveCategoryFromProject
        Task<bool> RemoveCategoryFromProjectAsync(int projectId, int categoryId);
        //AddTechnologyToProject
        Task<bool> AddTechnologyToProjectAsync(int projectId, int technologyId);
        //RemoveTechnologyFromProject
        Task<bool> RemoveTechnologyFromProjectAsync(int projectId, int technologyId);
    }
}
