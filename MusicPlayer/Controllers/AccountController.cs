using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Models;
using MusicPlayer.Models.RequestModels;
using MusicPlayer.Models.ResponseModels;
using MusicPlayer.Services;
using System.Security.Claims;

namespace MusicPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthentService _authentService;
        private readonly IMapper _mapper;

        public AccountController(IAuthentService authentService, IMapper mapper)
        {
            _authentService = authentService;
            _mapper = mapper;
        }

        [HttpGet("get-infor")]
        [Authorize]
        public async Task<IActionResult> GetInformation()
        {
            var identity = User.Identity as ClaimsIdentity;
            var result = await _authentService.GetInformation(identity);
            return Ok(new ReturnResponse<UserResponse>(_mapper.Map<UserResponse>(result)));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest model)
        {
            var token = await _authentService.LoginAsync(_mapper.Map<User>(model));
            return token == null ? Unauthorized("Login failed") : Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest model)
        {
            var user = _mapper.Map<User>(model);
            user.Role = Role.User;
            user.Id = Guid.NewGuid().ToString();
            var result = await _authentService.RegisterAsync(user);
            return Ok(new ReturnResponse<UserResponse>(_mapper.Map<UserResponse>(result)));
        }
    }
}

