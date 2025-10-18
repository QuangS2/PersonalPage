using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.Service;
using Application.DTOs;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //iservice
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //register user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest userRequest)
        {
            var result = await _userService.AddUserAsync(userRequest);
            if (!result)
            {
                return BadRequest("User registration failed.");
            }
            return Ok("User registered successfully.");
        }
        //update user
        [HttpPut("update/{userName}")]
        public async Task<IActionResult> Update(string userName, [FromBody] UpdateUserRequest userRequest)
        {
            var result = await _userService.UpdateUserAsync(userName, userRequest);
            if (!result)
            {
                return BadRequest("User update failed.");
            }
            return Ok("User updated successfully.");
        }
        //get user by username
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _userService.GetUserByUserNameAsync(userName);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }
    }
}

