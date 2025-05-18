using SmartEvent.Core.Models;

namespace SmartEvent.Core.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync(User newUser);
        public Task<User?> GetUserByIdAsync(Guid id);
        public Task<User?> GetUserByAuthIdAsync(Guid id);
        public Task<User?> UpdateUserAsync(Guid id, User updatedUser);
        public Task<List<User>> GetAllUserAsync();
        public Task<bool> DeleteUser(Guid id);
    }
}