using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DTO -> Entity
            CreateMap<RegisterUserRequest, ApplicationUser>();
            CreateMap<UpdateUserRequest, ApplicationUser>();
            //skillDTOs
            CreateMap<SkillDto, Skills>();
            CreateMap<SkillCreateDto, Skills>();
            CreateMap<SkillUpdateDto, Skills>();
            //projectDTOs
            CreateMap<ProjectDto, Projects>();
            CreateMap<ProjectCreateDto, Projects>();
            CreateMap<ProjectUpdateDto, Projects>();
            // CategoryDTOs
            CreateMap<CategoryDto, Categories>();
            CreateMap<CategoryCreateDto, Categories>();
            CreateMap<CategoryUpdateDto, Categories>();
            // TechnologyDTOs
            CreateMap<TechnologyDto, Technologies>();
            CreateMap<TechnologyCreateDto, Technologies>();
            CreateMap<TechnologyUpdateDto, Technologies>();



            // Entity -> DTO

            CreateMap<ApplicationUser, UserDto>();
            //skillDTOs
            CreateMap<Skills, SkillDto>();
            //projectDTOs
            CreateMap<Projects, ProjectDto>();
            // CategoryDTOs
            CreateMap<Categories, CategoryDto>();
            // TechnologyDTOs
            CreateMap<Technologies, TechnologyDto>();
        }
    }
}
