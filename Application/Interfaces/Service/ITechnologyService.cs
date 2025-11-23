using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface ITechnologyService
    {
        //create
        Task<TechnologyDto> CreateTechnologyAsync(TechnologyCreateDto technologyCreateDto);
        //read
        Task<TechnologyDto?> GetTechnologyByIdAsync(int id);
        //update
        Task<bool> UpdateTechnologyAsync(int id, TechnologyUpdateDto technologyUpdateDto);
        //delete
        Task<bool> DeleteTechnologyAsync(int id);
    }
}
