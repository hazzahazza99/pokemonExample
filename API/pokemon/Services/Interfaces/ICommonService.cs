using Pokemon.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services.Interfaces
{
    public interface ICommonService
    {
        Task<GridCommonDto> GetAllData();
        Task<List<PokeTypeDto>> GetAllTypes();
        Task<List<MoveDto>> GetAllMoves();
        Task<List<RegionDto>> GetAllRegions();
        Task<List<TrainerDto>> GetAllTrainers();
    }
}