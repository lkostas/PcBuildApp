using PcBuildApp.Data;
using PcBuildApp.DTO;
using PcBuildApp.Repository.Interfaces;


namespace PcBuildApp.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        public User UserMapper(UserRegistrationDTO userRegistrationDto)
        {
            return new User
            {
                UserName = userRegistrationDto.UserName,
                Email = userRegistrationDto.Email,
                Password = userRegistrationDto.Password,
                FirstName = userRegistrationDto.FirstName,
                LastName = userRegistrationDto.LastName,
                UserRole = PcBuildApp.Enums.UserRole.User,
                IsActive = true
            };
        }
    }
}