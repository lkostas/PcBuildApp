using PcBuildApp.Data;
using PcBuildApp.DTO;

namespace PcBuildApp.Services.Interfaces
{
    public interface IBuildService
    {
        Task<Build> CreateNewBuildAsync(Build build);
    }
}