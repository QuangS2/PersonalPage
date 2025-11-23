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
    public class SkillService : ISkillService
    {
        //repository
        private readonly ISkillRepository _skillRepository;
        private readonly IUserRepository _userRepository;
        //mapper
        private readonly IMapper _mapper;
        
        public SkillService(ISkillRepository skillRepository, IMapper mapper, IUserRepository userRepository)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }


        public async Task<bool> DeleteSkillAsync(int id)
        {
            //get existing skill
            var existingSkill = await _skillRepository.GetSkillByIdAsync(id);
            if (existingSkill == null)
            {
                return false; // Skill not found
            }
            //delete skill
            // Assuming the repository has a DeleteSkillAsync method
            await _skillRepository.DeleteSkillAsync(existingSkill);
            return true;
        }

        public async Task<IEnumerable<SkillDto>> GetSkillsByUserNameAsync(string userName)
        {
            //get all skills by username
            var skills = await _skillRepository.GetAllSkillsByUsernameAsync(userName);
            //map to dto
            var skillDtos = _mapper.Map<IEnumerable<SkillDto>>(skills);
            return skillDtos;
        }

        public async Task<SkillDto?> GetSkillByIdAsync(int id)
        {
            //get skill by id
            var skill = await _skillRepository.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return null;
            }
            //map to dto
            var skillDto = _mapper.Map<SkillDto>(skill);
            return skillDto;
        }

        public async Task<bool> UpdateSkillAsync(int id, SkillUpdateDto skillUpdateDto)
        {
            //get existing skill
            var existingSkill = await _skillRepository.GetSkillByIdAsync(id);
            if (existingSkill == null)
            {
                return false; // Skill not found
            }
            //update skill properties
            existingSkill.SkillName = skillUpdateDto.SkillName;
            existingSkill.ProficiencyPercentage = skillUpdateDto.Proficiency;
            //save changes
            await _skillRepository.UpdateSkillAsync(existingSkill);
            return true;
        }

        public async Task<SkillDto> CreateSkillAsync(SkillCreateDto skillCreateDto, string userName)
        {
            //get user by username
            var user = await _userRepository.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            //map skill
            var skill = _mapper.Map<Skills>(skillCreateDto);
            skill.UserId = user.Id;
            //create skill
            var createdSkill = await _skillRepository.CreateSkillAsync(skill);
            //map to dto
            var skillDto = _mapper.Map<SkillDto>(createdSkill);
            return skillDto;

        }
    }
}
