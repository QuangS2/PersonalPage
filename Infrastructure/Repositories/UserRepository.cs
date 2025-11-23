using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        //dbcontext
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(ApplicationUser user)
        {
            await _context.ApplicationUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser?> GetUserByUserNameAsync(string userName)
        {
            return await Task.FromResult(_context.ApplicationUsers.FirstOrDefault(u => u.UserName == userName));
        }
    }
}
