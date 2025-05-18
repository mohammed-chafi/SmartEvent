using Microsoft.EntityFrameworkCore;
using SmartEvent.Core.Interfaces;
using SmartEvent.Core.Models;
using SmartEvent.Data.Db;

namespace SmartEvent.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            newUser.Id = Guid.NewGuid();
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var userToDelete = await GetUserByIdAsync(id);
            if (userToDelete == null) return false;
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByAuthIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.AuthId == id);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User?> UpdateUserAsync(Guid id, User updatedUser)
        {
            var existingUser = await GetUserByIdAsync(id);
            if (existingUser == null) return null;

            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;


            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}