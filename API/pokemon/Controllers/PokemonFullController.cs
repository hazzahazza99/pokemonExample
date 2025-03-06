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
                .Include(p => p.EvolutionGroup).ThenInclude(eg => eg.EvolutionStages)
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
                .Include(p => p.EvolutionGroup).ThenInclude(eg => eg.EvolutionStages)
                .AsSplitQuery()
                .ToListAsync();

            if (!pokemonList.Any())
                return NotFound();

            var pokemonDtos = _mapper.Map<List<PokemonFullDto>>(pokemonList);
            return Ok(pokemonDtos);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonFullDto>> CreatePokemonFull(PokemonFullDto pokemonDto)
        {
            if (!pokemonDto.Types.Any() || !pokemonDto.Moves.Any())
                return BadRequest("At least one type and move is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var pokemon = _mapper.Map<PokemonData>(pokemonDto);
                _context.Pokemon.Add(pokemon);
                await _context.SaveChangesAsync();

                await ProcessRelationships(pokemon, pokemonDto);

                await transaction.CommitAsync();
                return CreatedAtAction(nameof(GetPokemonFull), new { id = pokemon.PokemonID }, _mapper.Map<PokemonFullDto>(pokemon));
            }
            catch
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "Error creating Pokémon.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePokemonFull(int id, PokemonFullDto pokemonDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var existingPokemon = await _context.Pokemon
                    .Include(p => p.PokemonTypes)
                    .Include(p => p.Moves)
                    .Include(p => p.Regions)
                    .Include(p => p.EvolutionGroup).ThenInclude(eg => eg.EvolutionStages)
                    .FirstOrDefaultAsync(p => p.PokemonID == id);

                if (existingPokemon == null)
                    return NotFound();

                _mapper.Map(pokemonDto, existingPokemon);
                await ProcessRelationships(existingPokemon, pokemonDto);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return NoContent();
            }
            catch
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "Error updating Pokémon.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemonFull(int id)
        {
            var pokemon = await _context.Pokemon
                .Include(p => p.EvolutionGroup)
                .FirstOrDefaultAsync(p => p.PokemonID == id);

            if (pokemon == null)
                return NotFound();

            _context.Pokemon.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task ProcessRelationships(PokemonData pokemon, PokemonFullDto dto)
        {
            _context.PokemonTypes.RemoveRange(_context.PokemonTypes.Where(pt => pt.TypesPokemonID == pokemon.PokemonID));
            _context.Movesets.RemoveRange(_context.Movesets.Where(m => m.MovesetPokemonID == pokemon.PokemonID));
            _context.PokemonRegions.RemoveRange(_context.PokemonRegions.Where(r => r.RegionsPokemonID == pokemon.PokemonID));
            await _context.SaveChangesAsync();

            _context.PokemonTypes.AddRange(dto.Types.Select(typeDto => new PokemonType { TypesPokemonID = pokemon.PokemonID, TypesPokeTypeID = typeDto.PokeTypeID }));
            _context.Movesets.AddRange(dto.Moves.Select(moveDto => new Moveset { MovesetPokemonID = pokemon.PokemonID, MovesetMoveID = moveDto.MoveID }));
            _context.PokemonRegions.AddRange(dto.Regions.Select(regionDto => new PokemonRegion { RegionsPokemonID = pokemon.PokemonID, RegionsRegionID = regionDto.RegionID }));

            if (dto.EvolutionStages != null)
            {
                var existingStages = await _context.EvolutionStages.Where(es => es.PokemonID == pokemon.PokemonID).ToListAsync();
                _context.EvolutionStages.RemoveRange(existingStages);
                await _context.SaveChangesAsync();

                foreach (var evolutionStageDto in dto.EvolutionStages)
                {
                    _context.EvolutionStages.Add(new EvolutionStage
                    {
                        PokemonID = pokemon.PokemonID,
                        GroupID = evolutionStageDto.GroupID,
                        StageOrder = evolutionStageDto.StageOrder
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

    }
}
