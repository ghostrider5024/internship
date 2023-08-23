using Microsoft.IdentityModel.Tokens;
using MusicPlayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicPlayer.Services
{
    public interface IAuthentService
    {
        public Task<string?> LoginAsync(User model);
        public Task<User?> RegisterAsync(User model);
        public Task<User?> GetInformation(ClaimsIdentity identity);
    }

    public class AuthentService : IAuthentService
    {
        private IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthentService(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
    
        public async Task<string?> LoginAsync(User model)
        {
            var user = await _userService.GetUserByUsernameAndPass(model);

            if (user == null) return null;

            return await GenToken(user);
        }

        public async Task<User?> RegisterAsync(User model)
        {
            return await _userService.CreateUserAsync(model);
        }

        private async Task<List<Claim>> GetAllClaims(User user)
        {
            var claims = new List<Claim>(){

                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Role, user.GenRole()),
                new Claim(ClaimTypes.Name, user.Username),
            };
            return claims;
        }

        public async Task<User?> GetInformation(ClaimsIdentity identity)
        {
            var userId = identity.FindFirst("Id")?.Value;

            return await _userService.GetUserById(userId);
        }

        private async Task<string?> GenToken(User user)
        {
            var authClaims = await GetAllClaims(user);

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecureKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuer"],
                audience: _configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}
