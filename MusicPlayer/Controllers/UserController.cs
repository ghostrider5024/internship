using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Models;
using MusicPlayer.Models.RequestModels;
using MusicPlayer.Models.ResponseModels;
using MusicPlayer.Services;

namespace MusicPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService UserService, IMapper mapper)
        {
            _userService = UserService;
            _mapper = mapper;
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(new ReturnResponse<List<UserResponse>>(_mapper.Map<List<UserResponse>>(result)));
        }

        [HttpPost("User")]
        public async Task<IActionResult> CreateUser(Role role, UserRequest request)
        {
            if (role == null)
                return BadRequest("Choose Role");
            var user = _mapper.Map<User>(request);
            user.Role = role;
            var result = await _userService.CreateUserAsync(user);
            return Ok(new ReturnResponse<UserResponse>(_mapper.Map<UserResponse>(result)));
        }

        [HttpPut("edit/{keyId}")]
        [Authorize(Roles = nameof(Role.User))]
        public async Task<IActionResult> UpdateUser(string keyId, UserResponse user)
        {
            var temp = _mapper.Map<User>(user);
            temp.Id = keyId;
            var result = await _userService.UpdateUserAsync(temp);
            return Ok(new ReturnResponse<UserResponse>(_mapper.Map<UserResponse>(result)));
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpDelete("delete/{keyId}")]
        public async Task<IActionResult> DeleteUser(string keyId)
        {
            var result = await _userService.DeleteUserAsync(keyId);
            var returnRes = new ReturnResponse<UserResponse>(_mapper.Map<UserResponse>(result)
                , messageSuccess: "Delete success", messageFail: "Delete failed");
            return Ok(returnRes);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest model)
        {
            var token = await _userService.LoginAsync(_mapper.Map<User>(model));
            return token == null ? Unauthorized("Login failed") : Ok(token);
        }
    }
}
