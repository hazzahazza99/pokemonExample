using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonFullController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PokemonFullController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonFullDto>> GetPokemonFull(int id)
        {
            var pokemon = await _context.Pokemon
                .Include(p => p.PokemonPicture)
                .Include(p => p.Trainer).ThenInclude(t => t.TrainerPhoto)
                .Include(p => p.PokemonTypes).ThenInclude(pt => pt.PokeType)
                .Include(p => p.Moves).ThenInclude(m => m.Move)
                .Include(p => p.Regions).ThenInclude(r => r.Region)
                .Include(p => p.EvolutionGroup).ThenInclude(eg => eg.EvolutionStages).ThenInclude(es => es.Pokemon)
                .FirstOrDefaultAsync(p => p.PokemonID == id);

            if (pokemon == null)
                return NotFound();

            var pokemonDto = _mapper.Map<PokemonFullDto>(pokemon);
            return Ok(pokemonDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PokemonFullDto>>> GetAllPokemonFull()
        {
            var pokemonList = await _context.Pokemon
                .Include(p => p.PokemonPicture)
                .Include(p => p.Trainer).ThenInclude(t => t.TrainerPhoto)
                .Include(p => p.PokemonTypes).ThenInclude(pt => pt.PokeType)
                .Include(p => p.Moves).ThenInclude(m => m.Move)
                .Include(p => p.Regions).ThenInclude(r => r.Region)
                .Include(p => p.EvolutionGroup).ThenInclude(eg => eg.EvolutionStages).ThenInclude(es => es.Pokemon)
                .ToListAsync();

            if (pokemonList == null || !pokemonList.Any())
                return NotFound();

            var pokemonDtos = _mapper.Map<List<PokemonFullDto>>(pokemonList);
            return Ok(pokemonDtos);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonFullDto>> CreatePokemonFull(PokemonFullDto pokemonDto)
        {
            var pokemon = _mapper.Map<PokemonData>(pokemonDto);
            _context.Pokemon.Add(pokemon);
            await _context.SaveChangesAsync();

            var createdPokemonDto = _mapper.Map<PokemonFullDto>(pokemon);
            return CreatedAtAction(nameof(GetPokemonFull), new { id = pokemon.PokemonID }, createdPokemonDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePokemonFull(int id, PokemonFullDto pokemonDto)
        {
            if (id != pokemonDto.PokemonID)
            {
                return BadRequest("ID mismatch");
            }

            var existingPokemon = await _context.Pokemon
                .Include(p => p.PokemonPicture)
                .Include(p => p.Trainer)
                .Include(p => p.PokemonTypes)
                .Include(p => p.Moves)
                .Include(p => p.Regions)
                .Include(p => p.EvolutionGroup)
                .FirstOrDefaultAsync(p => p.PokemonID == id);

            if (existingPokemon == null)
            {
                return NotFound();
            }

            _mapper.Map(pokemonDto, existingPokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemonFull(int id)
        {
            var pokemon = await _context.Pokemon
                .Include(p => p.PokemonPicture)
                .Include(p => p.Trainer)
                .Include(p => p.PokemonTypes)
                .Include(p => p.Moves)
                .Include(p => p.Regions)
                .Include(p => p.EvolutionGroup)
                .FirstOrDefaultAsync(p => p.PokemonID == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            _context.Pokemon.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}