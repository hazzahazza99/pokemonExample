using Pokemon.Dtos;
using Pokemon.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly List<TrainerDto> _mockTrainers = new()
    {
        new TrainerDto
        {
            TrainerID = 1,
            TrainerName = "Brock",
            TrainerAge = 28,
            TrainerBadge = 5,
            TrainerIsGymLeader = true,
            TrainerPhotoID = 9
        }
    };

        public async Task<List<TrainerDto>> GetAllTrainers()
        {
            return await Task.FromResult(_mockTrainers);
        }
    }
}