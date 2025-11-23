using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
namespace Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        //dbcontext
        private readonly ApplicationDbContext _context;
        //mapper
        private readonly IMapper _mapper;
        public SkillRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Skills> CreateSkillAsync(Skills skill)
        {
            _context.Skills.Add(skill);
            await  _context.SaveChangesAsync();
            return skill;
        }

        public async Task DeleteSkillAsync(Skills skill)
        {
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Skills>> GetAllSkillsByUsernameAsync(string username)
        {
            return await Task.FromResult(_context.Skills.Where(s => s.User.UserName == username).AsEnumerable());
        }

        public async Task<Skills?> GetSkillByIdAsync(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<Skills> UpdateSkillAsync(Skills skill)
        {
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return skill;
        }
    }
}
