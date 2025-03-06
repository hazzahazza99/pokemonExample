using Pokemon.Dtos;
using Pokemon.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public class RegionService : IRegionService
    {
        private readonly List<RegionDto> _mockRegions = new()
    {
        new RegionDto
        {
            RegionID = 1,
            RegionName = "Kanto",
            RegionDescription = "The starting region for many Pokémon trainers"
        }
    };

        public async Task<List<RegionDto>> GetAllRegions()
        {
            return await Task.FromResult(_mockRegions);
        }
    }
}