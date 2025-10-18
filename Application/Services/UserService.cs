using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Application.Services
{
    public class UserService : IUserService
    {
        //irepository
        private readonly IUserRepository _userRepository;
        //mapper
        private readonly IMapper _mapper;
        //user manager
        private readonly UserManager<ApplicationUser> _userManager; 
        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> AddUserAsync(RegisterUserRequest userRequest)
        {
            //check user exists
            var existingUser = await _userManager.FindByNameAsync(userRequest.UserName);
            if (existingUser != null)
            {
                return false; // User already exists
            }
            //map user
            var user = _mapper.Map<ApplicationUser>(userRequest);
            //create user
            var result = await _userManager.CreateAsync(user, userRequest.Password);
            if (!result.Succeeded)
            {
                return false; // User creation failed
            }
            return true;
        }

        public async Task<UserDto?> GetUserByUserNameAsync(string userName)
        {
            //get user by username
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return null; // User not found
            }
            //map user to dto
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<bool> UpdateUserAsync(string userName, UpdateUserRequest userRequest)
        {
            //get user by username
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return false; // User not found
            }
            //map user
            _mapper.Map(userRequest, user);
            //update user
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return false; // User update failed
            }
            return true;
        }
    }
}
