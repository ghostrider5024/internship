using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Repositories;

namespace MusicPlayer.Services
{
    public interface IUserService
    {
        public Task<ICollection<User>> GetAllUsersAsync();
        public Task<User> CreateUserAsync(User model);
        public Task<User> UpdateUserAsync(User model);
        public Task<User> DeleteUserAsync(string id);

        public Task<string?> LoginAsync(User model);
    }
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _UserRepository;

        public UserService(IMapper mapper, UserRepository UserRepository)
        {
            _mapper = mapper;
            _UserRepository = UserRepository;
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            var Users = await _UserRepository.GetUsers();
            return Users.ToList();
        }

        public async Task<User> CreateUserAsync(User model)
        {
            var result = await _UserRepository.CreateUserAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<User> UpdateUserAsync(User model)
        {
            var result = await _UserRepository.UpdateUserAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<User> DeleteUserAsync(string id)
        {
            var result = await GetUserById(id);
            if (result != null)
            {
                result.DeleteDate = DateTime.Now;
                return await UpdateUserAsync(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUserById(string Id)
        {
            return await _UserRepository.GetById(Id);
        }

        public async Task<string?> LoginAsync(User model)
        {
            return await _UserRepository.LoginAsync(model);
        }
    }
}
