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
    public class PokemonController : ControllerBase
    {
        private readonly DataContext _context;

        public PokemonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonFullDto>> GetPokemon(int id)
        {
            var pokemon = await _context.Pokemon
                .Include(p => p.PokemonPicture)
                .Include(p => p.Trainer)
                    .ThenInclude(t => t.TrainerPhoto)
                .Include(p => p.PokemonTypes)
                    .ThenInclude(pt => pt.PokeType)
                .Include(p => p.Moves)
                    .ThenInclude(m => m.Move)
                .Include(p => p.Regions)
                    .ThenInclude(r => r.Region)
                .Include(p => p.EvolutionGroup)
                    .ThenInclude(eg => eg.EvolutionStages)
                        .ThenInclude(es => es.Pokemon)
                .FirstOrDefaultAsync(p => p.PokemonID == id);

            if (pokemon == null)
                return NotFound();

            var pokemonDto = new PokemonFullDto
            {
                PokemonID = pokemon.PokemonID,
                PokemonName = pokemon.PokemonName,
                PicturePath = pokemon.PokemonPicture?.PicturePath,
                Trainer = pokemon.Trainer == null ? null : new TrainerDto
                {
                    TrainerID = pokemon.Trainer.TrainerID,
                    TrainerName = pokemon.Trainer.TrainerName,
                    TrainerAge = pokemon.Trainer.TrainerAge,
                    TrainerBadge = pokemon.Trainer.TrainerBadge,
                    TrainerIsGymLeader = pokemon.Trainer.TrainerIsGymLeader,
                    TrainerPhotoPath = pokemon.Trainer.TrainerPhoto?.PicturePath
                },
                Types = pokemon.PokemonTypes.Select(pt => pt.PokeType.TypeName).ToList(),
                Moves = pokemon.Moves.Select(m => m.Move.MoveName).ToList(),
                Regions = pokemon.Regions.Select(r => r.Region.RegionName).ToList(),
                EvolutionGroup = pokemon.EvolutionGroup == null ? null : new EvolutionGroupDto
                {
                    GroupID = pokemon.EvolutionGroup.EvolutionGroupID,
                    EvolutionStages = pokemon.EvolutionGroup.EvolutionStages
                        .OrderBy(es => es.StageOrder)
                        .Select(es => new EvolutionStageDto
                        {
                            StageOrder = es.StageOrder,
                            Pokemon = new SimplePokemonDto
                            {
                                PokemonID = es.Pokemon.PokemonID,
                                Name = es.Pokemon.PokemonName
                            }
                        }).ToList()
                }
            };

            return Ok(pokemonDto);
        }
    }
}