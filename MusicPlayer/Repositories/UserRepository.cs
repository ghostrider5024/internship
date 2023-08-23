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

        public async Task<User?> GetUser(User model)
        {
            return await _context.Set<User>()
                .Where(t => t.Username == model.Username && t.Password == model.Password)
                .FirstOrDefaultAsync();
        }


    }
}
