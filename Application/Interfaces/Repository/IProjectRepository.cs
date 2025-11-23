using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IProjectRepository
    {
        //create Async
        Task<Projects> CreateProjectAsync(Projects project);
        //Get Project By Id Async
        Task<Projects?> GetProjectByIdAsync(int id);
        //Delete Project Async
        Task DeleteProjectAsync(Projects project);
        //Get All Projects By Username Async
        Task<IEnumerable<Projects>> GetAllProjectsByUsernameAsync(string username);
        //Update Project Async
        Task<Projects> UpdateProjectAsync(Projects project);
        //AddCategoryToProjectAsync
        Task AddCategoryToProjectAsync(int projectId, int categoryId);
        //RemoveCategoryFromProjectAsync
        Task RemoveCategoryFromProjectAsync(int projectId, int categoryId);
        //AddTechnologyToProjectAsync
        Task AddTechnologyToProjectAsync(int projectId, int technologyId);
        //RemoveTechnologyFromProjectAsync
        Task RemoveTechnologyFromProjectAsync(int projectId, int technologyId);
    }
}
