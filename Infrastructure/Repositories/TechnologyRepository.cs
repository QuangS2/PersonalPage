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
    public class TechnologyRepository : ITechnologyRepository
    {
        //dbcontext
        private readonly ApplicationDbContext _context;
        //mapper
        private readonly IMapper _mapper;
        public TechnologyRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Technologies> CreateTechnologyAsync(Technologies technology)
        {
            await _context.Technologies.AddAsync(technology);
            await _context.SaveChangesAsync();
            return technology;
        }

        public async Task<bool> DeleteTechnologyAsync(Technologies technology)
        {
            var existingTechnology = await _context.Technologies.FindAsync(technology.Id);
            if (existingTechnology == null)
            {
                return false;
            }
            _context.Technologies.Remove(existingTechnology);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Technologies?> GetTechnologyByIdAsync(int id)
        {
            return await _context.Technologies.FindAsync(id);
        }

        public async Task<Technologies> UpdateTechnologyAsync(Technologies technology)
        {
            var existingTechnology = await _context.Technologies.FindAsync(technology.Id);
            if (existingTechnology == null)
            {
                throw new Exception("Technology not found");
            }
            //mapping updated fields
            _mapper.Map(technology, existingTechnology);
            await _context.SaveChangesAsync();
            return technology;
        }
    }
}
