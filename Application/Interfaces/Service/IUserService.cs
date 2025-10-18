using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface IUserService
    {
        //add user
        Task<bool> AddUserAsync(RegisterUserRequest userRequest);
        //update user
        Task<bool> UpdateUserAsync(string userName, UpdateUserRequest userRequest);
        //get user by username
        Task<UserDto?> GetUserByUserNameAsync(string userName);
    }
}
