using Pokemon.Dtos;
using Pokemon.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Services.Interfaces;

namespace Pokemon.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TrainerService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TrainerDto>> GetAllTrainers()
        {
            var trainers = await _context.Trainers
                .AsNoTracking()
                .ProjectTo<TrainerDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return trainers;
        }
    }
}