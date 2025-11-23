using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TechnologyService : ITechnologyService
    {
        //repository
        private readonly ITechnologyRepository technologyRepository;
        //mapper
        private readonly IMapper _mapper;
        public TechnologyService(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            this.technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<TechnologyDto> CreateTechnologyAsync(TechnologyCreateDto technologyCreateDto)
        {
            var technologyEntity = _mapper.Map<Domain.Entities.Technologies>(technologyCreateDto);
            var createdTechnology = await technologyRepository.CreateTechnologyAsync(technologyEntity);
            return _mapper.Map<TechnologyDto>(createdTechnology);
        }

        public async Task<bool> DeleteTechnologyAsync(int id)
        {
            var technology = await technologyRepository.GetTechnologyByIdAsync(id);
            if (technology == null)
            {
                return false;
            }
            return await technologyRepository.DeleteTechnologyAsync(technology);
        }

        public async Task<TechnologyDto?> GetTechnologyByIdAsync(int id)
        {
            var technology = await technologyRepository.GetTechnologyByIdAsync(id);
            if (technology == null)
            {
                return null;
            }
            return _mapper.Map<TechnologyDto>(technology);
        }

        public async Task<bool> UpdateTechnologyAsync(int id, TechnologyUpdateDto technologyUpdateDto)
        {
            var existingTechnology = await technologyRepository.GetTechnologyByIdAsync(id);
            if (existingTechnology == null)
            {
                return false;
            }
            _mapper.Map(technologyUpdateDto, existingTechnology);
            await technologyRepository.UpdateTechnologyAsync(existingTechnology);
            return true;
        }
    }
}
