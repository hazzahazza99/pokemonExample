using Pokemon.Dtos;
using Pokemon.Models;
using Pokemon.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public class CommonService : ICommonService
    {
        private readonly ITypeService _typeService;
        private readonly IMoveService _moveService;
        private readonly IRegionService _regionService;
        private readonly ITrainerService _trainerService;

        public CommonService(
            ITypeService typeService,
            IMoveService moveService,
            IRegionService regionService,
            ITrainerService trainerService)
        {
            _typeService = typeService;
            _moveService = moveService;
            _regionService = regionService;
            _trainerService = trainerService;
        }

        public async Task<GridCommonDto> GetAllData()
        {
            var types = await _typeService.GetAllTypes();
            var moves = await _moveService.GetAllMoves();
            var regions = await _regionService.GetAllRegions();
            var trainers = await _trainerService.GetAllTrainers();


            return new GridCommonDto
            {
                Types = types,
                Moves = moves,
                Regions = regions,
                Trainers = trainers
            };
        }

        public async Task<List<PokeTypeDto>> GetAllTypes() => await _typeService.GetAllTypes();
        public async Task<List<MoveDto>> GetAllMoves() => await _moveService.GetAllMoves();
        public async Task<List<RegionDto>> GetAllRegions() => await _regionService.GetAllRegions();
        public async Task<List<TrainerDto>> GetAllTrainers() => await _trainerService.GetAllTrainers();
    }
}