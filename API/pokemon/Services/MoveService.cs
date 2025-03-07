using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public class MoveService : IMoveService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MoveService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MoveDto>> GetAllMoves()
        {
            var moves = await _context.Moves
                .AsNoTracking()
                .ProjectTo<MoveDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return moves;
        }
    }
}