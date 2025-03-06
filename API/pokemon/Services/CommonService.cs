using Pokemon.Dtos;
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
            var typesTask = _typeService.GetAllTypes();
            var movesTask = _moveService.GetAllMoves();
            var regionsTask = _regionService.GetAllRegions();
            var trainersTask = _trainerService.GetAllTrainers();

            await Task.WhenAll(typesTask, movesTask, regionsTask, trainersTask);

            return new GridCommonDto
            {
                Types = await typesTask,
                Moves = await movesTask,
                Regions = await regionsTask,
                Trainers = await trainersTask
            };
        }

        public async Task<List<PokeTypeDto>> GetAllTypes() => await _typeService.GetAllTypes();
        public async Task<List<MoveDto>> GetAllMoves() => await _moveService.GetAllMoves();
        public async Task<List<RegionDto>> GetAllRegions() => await _regionService.GetAllRegions();
        public async Task<List<TrainerDto>> GetAllTrainers() => await _trainerService.GetAllTrainers();
    }
}