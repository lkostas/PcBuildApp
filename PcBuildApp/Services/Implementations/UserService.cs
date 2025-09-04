using Microsoft.EntityFrameworkCore;
using PcBuildApp.Data;
using PcBuildApp.DTO;
using PcBuildApp.Services.Interfaces;

namespace PcBuildApp.Services.Implementations
{
    public class UserService(PcBuildAppDbContext context) : IUserService
    {
        readonly PcBuildAppDbContext _context = context;

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateNewUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}