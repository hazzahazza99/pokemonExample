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
    public class GetPokemonByNameController : ControllerBase
    {
        private readonly DataContext _context;

        public GetPokemonByNameController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("pokemon/{pokemonName}")]
        public async Task<IActionResult> GetPokemonByName(string pokemonName)
        {
            var pokemon = await _context.PokemonData
                .Where(p => p.PokemonName == pokemonName)
                .Include(p => p.Picture)
                .Include(p => p.Trainer)
                .Include(p => p.PokemonRegions)
                .ThenInclude(pr => pr.Region)
                .Include(p => p.Movesets)
                .ThenInclude(ms => ms.Move)
                .Include(p => p.EvolutionGroup)
                .FirstOrDefaultAsync();

            if (pokemon == null)
            {
                return NotFound();
            }

            var pokemonDto = new PokemonDataDto
            {
                PokemonID = pokemon.PokemonID,
                PokemonName = pokemon.PokemonName,
                TrainerID = pokemon.TrainerID,
                PictureID = pokemon.Picture?.PictureID, 
                PictureURL = pokemon.Picture?.PictureURL, 
                Trainer = pokemon.Trainer != null ? new TrainerDto
                {
                    TrainerID = pokemon.Trainer.TrainerID,
                    TrainerName = pokemon.Trainer.TrainerName,
                    TrainerAge = pokemon.Trainer.TrainerAge,
                    TrainerBadge = pokemon.Trainer.TrainerBadge,
                    IsGymLeader = pokemon.Trainer.IsGymLeader
                } : null,
                PokemonRegions = pokemon.PokemonRegions.Select(pr => new PokemonRegionDto
                {
                    RegionID = pr.Region.RegionID,
                    RegionName = pr.Region.RegionName,
                    RegionDescription = pr.Region.RegionDescription
                }).ToList(),
                Movesets = pokemon.Movesets.Select(ms => new MovesetDto
                {
                    MoveID = ms.Move.MoveID,
                    MoveName = ms.Move.MoveName
                }).ToList(),
                EvolutionGroup = pokemon.EvolutionGroup != null ? new EvolutionGroupDto
                {
                    EvolutionGroupID = pokemon.EvolutionGroup.EvolutionGroupID,
                    EvolutionGroupName = pokemon.EvolutionGroup.EvolutionGroupName
                } : null
            };

            return Ok(pokemonDto);
        }

    }

}
