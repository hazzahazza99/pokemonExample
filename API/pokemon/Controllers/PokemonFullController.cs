using AutoMapper;
using AutoMapper.QueryableExtensions;
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
                .AsSplitQuery()
                .ToListAsync();

            if (pokemonList == null || !pokemonList.Any())
                return NotFound();

            var pokemonDtos = _mapper.Map<List<PokemonFullDto>>(pokemonList);
            return Ok(pokemonDtos);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonFullDto>> CreatePokemonFull(PokemonFullDto pokemonDto)
        {
            if (pokemonDto.Types.Count == 0)
                return BadRequest("At least one type is required");

            if (pokemonDto.Moves.Count == 0)
                return BadRequest("At least one move is required");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var pokemon = new PokemonData
                {
                    PokemonName = pokemonDto.PokemonName,
                    PokemonPictureID = pokemonDto.PokemonPictureID,
                    PokemonTrainerID = pokemonDto.PokemonTrainerID,
                    EvolutionGroupID = pokemonDto.EvolutionGroupID
                };

                _context.Pokemon.Add(pokemon);
                await _context.SaveChangesAsync();

                await ProcessRelationships(pokemon, pokemonDto);

                await transaction.CommitAsync();
                return CreatedAtAction(nameof(GetPokemonFull), new { id = pokemon.PokemonID }, pokemonDto);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "Error creating Pokémon" + ex.InnerException?.Message);
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
                    .FirstOrDefaultAsync(p => p.PokemonID == id);

                if (existingPokemon == null)
                    return NotFound();

                _mapper.Map(pokemonDto, existingPokemon);

                await ProcessRelationships(existingPokemon, pokemonDto);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "Error updating Pokemon" + ex.InnerException?.Message);
            }
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
                return NotFound();

            _context.Pokemon.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task ProcessRelationships(PokemonData pokemon, PokemonFullDto dto)
        {
            foreach (var typeDto in dto.Types)
            {
                var pokemonType = new PokemonType
                {
                    TypesPokemonID = pokemon.PokemonID,
                    TypesPokeTypeID = typeDto.PokeTypeID
                };
                _context.PokemonTypes.Add(pokemonType);
            }

            foreach (var moveDto in dto.Moves)
            {
                var pokemonMove = new Moveset
                {
                    MovesetPokemonID = pokemon.PokemonID,
                    MovesetMoveID = moveDto.MoveID
                };
                _context.Movesets.Add(pokemonMove);
            }

            foreach (var regionDto in dto.Regions)
            {
                var pokemonRegion = new PokemonRegion
                {
                    RegionsPokemonID = pokemon.PokemonID,
                    RegionsRegionID = regionDto.RegionID
                };
                _context.PokemonRegions.Add(pokemonRegion);
            }

            /*foreach (var evolutionDto in dto.EvolutionStages)
            {
                var evolutionStage = new EvolutionStage
                {
                    GroupID = evolutionDto.GroupID,
                    StageOrder = evolutionDto.StageOrder,
                    PokemonID = pokemon.PokemonID
                };

                _context.EvolutionStages.Add(evolutionStage);
            }*/


            await _context.SaveChangesAsync();
        }
    }
}
