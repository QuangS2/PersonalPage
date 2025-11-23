using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface ISkillService
    {
        //get all skills async
        Task<IEnumerable<SkillDto>> GetSkillsByUserNameAsync(string userName);
        //get skill by id async
        Task<SkillDto?> GetSkillByIdAsync(int id);
        //create skill async
        Task<SkillDto> CreateSkillAsync(SkillCreateDto skillCreateDto, string userName);
        //update skill async
        Task<bool> UpdateSkillAsync(int id, SkillUpdateDto skillUpdateDto);
        //delete skill async
        Task<bool> DeleteSkillAsync(int id);

    }
}
