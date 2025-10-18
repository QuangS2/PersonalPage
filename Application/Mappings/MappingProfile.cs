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
            // Entity -> DTO

            CreateMap<ApplicationUser, UserDto>();
        }
    }
}
