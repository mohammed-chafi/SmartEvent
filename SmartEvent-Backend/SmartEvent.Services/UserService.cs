using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;

namespace SmartEvent.Services
{
    public class UserService
    {
        private readonly IUserRepository _userReposiroty;

        public UserService(IUserRepository userRepository)
        {
            _userReposiroty = userRepository;
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            return await _userReposiroty.CreateUserAsync(newUser);
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userReposiroty.DeleteUser(id);
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _userReposiroty.GetAllUserAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _userReposiroty.GetUserByIdAsync(id);
        }

        public async Task<User?> GetUserByAuthIdAsync(Guid id)
        {
            return await _userReposiroty.GetUserByAuthIdAsync(id);
        }

        public async Task<User?> UpdateUserAsync(Guid id, User updatedUser)
        {
            return await _userReposiroty.UpdateUserAsync(id, updatedUser);
        }

    }
}