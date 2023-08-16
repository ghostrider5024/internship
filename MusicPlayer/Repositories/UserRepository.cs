using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicPlayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicPlayer.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IQueryable<User>> GetUsers()
        {
            return _context.Set<User>()
                .Where(t => t.DeleteDate == null);
        }

        public async Task<User> CreateUserAsync(User model)
        {
            model.DeleteDate = null;
            return await Add(model);
        }

        public async Task<User> UpdateUserAsync(User model)
        {
            return await Update(model);
        }

        public async Task<string?> LoginAsync(User model)
        {
            var user = await GetUser(model);
            if (user == null) return null;
            if(user.Password != model.Password)
                return null;
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

        private async Task<List<Claim>> GetAllClaims(User user)
        {
            var claims = new List<Claim>(){

                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Role, user.GenRole()),
                new Claim(ClaimTypes.Name, user.Username),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //var userClaims = await userManager.GetClaimsAsync(user);
            //claims.AddRange(userClaims);

            //var userRoles = await userManager.GetRolesAsync(user);
            //foreach (var userRole in userRoles)
            //{
            //    var role = await roleManager.FindByNameAsync(userRole);

            //    if (role != null)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, userRole));


            //        var roleClaims = await roleManager.GetClaimsAsync(role);
            //        foreach (var roleClaim in roleClaims)
            //        {
            //            claims.Add(roleClaim);
            //        }
            //    }
            //}
            return claims;
        }

        protected async Task<User> GetUser(User model)
        {
            return await _context.Set<User>()
                .Where(t => t.Username == model.Username && t.Password == model.Password)
                .FirstOrDefaultAsync();
        }


    }
}
