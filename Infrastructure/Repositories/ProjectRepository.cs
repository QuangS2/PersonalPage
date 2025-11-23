using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        //dbcontext
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task AddCategoryToProjectAsync(int projectId, int categoryId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            var category = await _context.Categories.FindAsync(categoryId);
            if (project == null || category == null)
            {
                throw new Exception("Project or Category not found");
            }
            project.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task AddTechnologyToProjectAsync(int projectId, int technologyId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            var technology = await _context.Technologies.FindAsync(technologyId);
            if (project == null || technology == null)
            {
                throw new Exception("Project or Technology not found");
            }
            project.Technologies.Add(technology);
            await _context.SaveChangesAsync();
        }

        public async Task<Projects> CreateProjectAsync(Projects project)
        {
            _context.Projects.Add(project);
            await  _context.SaveChangesAsync();
            return project;
        }

        public async Task DeleteProjectAsync(Projects project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Projects>> GetAllProjectsByUsernameAsync(string username)
        {
            return await Task.FromResult(_context.Projects.Where(p => p.User.UserName == username).ToList());
        }

        public async Task<Projects?> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task RemoveCategoryFromProjectAsync(int projectId, int categoryId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            var category = await _context.Categories.FindAsync(categoryId);
            if (project == null || category == null)
            {
                throw new Exception("Project or Category not found");
            }
            project.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTechnologyFromProjectAsync(int projectId, int technologyId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            var technology = await _context.Technologies.FindAsync(technologyId);
            if (project == null || technology == null)
            {
                throw new Exception("Project or Technology not found");
            }
            project.Technologies.Remove(technology);
            await _context.SaveChangesAsync();
        }

        public async Task<Projects> UpdateProjectAsync(Projects project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }
    }
}
