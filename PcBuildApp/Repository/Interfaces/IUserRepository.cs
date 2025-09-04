using PcBuildApp.Data;
using PcBuildApp.DTO;

namespace PcBuildApp.Repository.Interfaces
{
    public interface IUserRepository
    {
        User UserMapper(UserRegistrationDTO userRegistrationDto);
    }
}