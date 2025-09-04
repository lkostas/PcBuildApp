using PcBuildApp.Data;

namespace PcBuildApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateNewUserAsync(User user);
    }
}