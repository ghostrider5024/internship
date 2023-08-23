using AutoMapper;
using MusicPlayer.Models;
using MusicPlayer.Repositories;

namespace MusicPlayer.Services
{
    public interface IUserService
    {
        public Task<ICollection<User>> GetAllUsersAsync();
        public Task<User?> GetUserByUsernameAndPass(User model);
        public Task<User?> GetUserById(string Id);
        public Task<User> CreateUserAsync(User model);
        public Task<User> UpdateUserAsync(User model);
        public Task<User> DeleteUserAsync(string id);
    }
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public UserService(IMapper mapper, UserRepository UserRepository)
        {
            _mapper = mapper;
            _userRepository = UserRepository;
        }

        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            var Users = await _userRepository.GetUsers();
            return Users.ToList();
        }

        

        public async Task<User> CreateUserAsync(User model)
        {
            var result = await _userRepository.CreateUserAsync(model);
            if (result != null)
            {
                return model;
            }
            return null;
        }

        public async Task<User> UpdateUserAsync(User model)
        {
            var result = await _userRepository.UpdateUserAsync(model);
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

        public async Task<User?> GetUserById(string Id)
        {
            return await _userRepository.GetById(Id);
        }
       
        public async Task<User?> GetUserByUsernameAndPass(User model)
        {
            return await _userRepository.GetUser(model);
        }
        
    }
}
