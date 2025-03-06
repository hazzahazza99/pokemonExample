using Pokemon.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services.Interfaces
{
    public interface IRegionService
    {
        Task<List<RegionDto>> GetAllRegions();
    }
}