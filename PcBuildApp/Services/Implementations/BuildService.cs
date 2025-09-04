using PcBuildApp.Data;
using PcBuildApp.Services.Interfaces;

namespace PcBuildApp.Services.Implementations
{
    public class BuildService(PcBuildAppDbContext context) : IBuildService
    {
        readonly PcBuildAppDbContext _context = context;

        public async Task<Build> CreateNewBuildAsync(Build build)
        {
            _context.Builds.Add(build);
            await _context.SaveChangesAsync();
            return build;
        }
    }
}