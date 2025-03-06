using Pokemon.Dtos;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pokemon.Services.Interfaces
{
    public interface ITrainerService
    {
        Task<List<TrainerDto>> GetAllTrainers();

    }
}