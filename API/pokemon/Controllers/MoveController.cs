using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoveController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MoveController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoveDto>>> GetAllMoves()
        {
            var moves = await _context.Moves
                .Include(m => m.MovePokeType)
                .ProjectTo<MoveDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(moves);
        }

        [HttpPost]
        public async Task<ActionResult<MoveDto>> CreateMove(MoveDto moveDto)
        {
            if (await _context.Moves.AnyAsync(m => m.MoveName == moveDto.MoveName))
                return BadRequest("Move with this name already exists");

            var move = _mapper.Map<Move>(moveDto);

            _context.Moves.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllMoves), _mapper.Map<MoveDto>(move));
        }
    }

}
