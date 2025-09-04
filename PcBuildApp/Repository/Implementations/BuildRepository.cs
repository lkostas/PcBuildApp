using PcBuildApp.Data;
using PcBuildApp.DTO;
using PcBuildApp.Repository.Interfaces;

namespace PcBuildApp.Repository.Implementations
{
    public class BuildRepository : IBuildRepository
    {
        public Build BuildMapper(BuildCreateDTO buildCreateDto)
        {
            return new Build
            {
                Name = buildCreateDto.Name,
                Description = buildCreateDto.Description,
                TotalPrice = 0,
                TotalWattage = 0,
                IsPublic = buildCreateDto.IsPublic,
                IsCompleted = buildCreateDto.IsCompleted
            };
        }
        
    }
}