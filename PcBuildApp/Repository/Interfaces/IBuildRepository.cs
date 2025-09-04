using PcBuildApp.Data;
using PcBuildApp.DTO;

namespace PcBuildApp.Repository.Interfaces
{
    public interface IBuildRepository
    {
        Build BuildMapper(BuildCreateDTO buildCreateDto);
    }
}