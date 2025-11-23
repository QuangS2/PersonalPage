using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        //repository
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        //mapper
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddCategoryToProjectAsync(int projectId, int categoryId)
        {
            //get project by id
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                return false; // Project not found
            }
            //add category to project
            await _projectRepository.AddCategoryToProjectAsync(projectId, categoryId);
            return true;
        }

        public async Task<bool> AddTechnologyToProjectAsync(int projectId, int technologyId)
        {
            //get project by id
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                return false; // Project not found
            }
            //add technology to project
            await _projectRepository.AddTechnologyToProjectAsync(projectId, technologyId);
            return true;
        }

        public async Task<ProjectDto> CreateProjectAsync(ProjectCreateDto projectCreateDto, string userName)
        {
            //map project
            var project = _mapper.Map<Projects>(projectCreateDto);
            //get user by username
            var user = await _userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            project.UserId = user.Id;
            //add project
            var createdProject = await _projectRepository.CreateProjectAsync(project);
            //map to dto
            var projectDto = _mapper.Map<ProjectDto>(createdProject);
            return projectDto;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            //get project by id
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return false; // Project not found
            }
            //delete project
            await _projectRepository.DeleteProjectAsync(project);
            return true;
        }

        public async Task<ProjectDto?> GetProjectByIdAsync(int id)
        {
            //get project by id
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return null; // Project not found
            }
            //map to dto
            var projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsByUserNameAsync(string userName)
        {
            //get all projects by username
            var projects = await _projectRepository.GetAllProjectsByUsernameAsync(userName);
            //map to dto
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            return projectDtos;
        }

        public async Task<bool> RemoveCategoryFromProjectAsync(int projectId, int categoryId)
        {
            //get project by id
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                return false; // Project not found
            }
            //remove category from project
            await _projectRepository.RemoveCategoryFromProjectAsync(projectId, categoryId);
            return true;
        }

        public async Task<bool> RemoveTechnologyFromProjectAsync(int projectId, int technologyId)
        {
            //get project by id
            var project = await _projectRepository.GetProjectByIdAsync(projectId);
            if (project == null)
            {
                return false; // Project not found
            }
            //remove technology from project
            await _projectRepository.RemoveTechnologyFromProjectAsync(projectId, technologyId);
            return true;
        }

        public async Task<bool> UpdateProjectAsync(int id, ProjectUpdateDto projectUpdateDto)
        {
            //get existing project
            var existingProject = await _projectRepository.GetProjectByIdAsync(id);
            if (existingProject == null)
            {
                return false; // Project not found
            }
            //map updated fields
            _mapper.Map(projectUpdateDto, existingProject);
            // Assuming the repository has an UpdateProjectAsync method
            await _projectRepository.UpdateProjectAsync(existingProject);
            return true;
        }
    }
}
