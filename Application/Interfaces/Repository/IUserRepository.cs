using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        //add user
        Task AddUserAsync(ApplicationUser user);
        //GetUserByUserNameAsync
        Task<ApplicationUser?> GetUserByUserNameAsync(string userName);
    }
}
