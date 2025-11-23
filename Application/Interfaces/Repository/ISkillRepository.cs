using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface ISkillRepository
    {
        //create Skill Async
        Task<Skills> CreateSkillAsync(Skills skill);
        //Get All Skills By Username Async
        Task<IEnumerable<Skills>> GetAllSkillsByUsernameAsync(string username);
        //GetSkillByIdAsync
        Task<Skills?> GetSkillByIdAsync(int id);
        //update skill async
        Task<Skills> UpdateSkillAsync(Skills skill);
        //delete skill async

        Task DeleteSkillAsync(Skills skill);
    }
}
