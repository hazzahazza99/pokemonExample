//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Pokemon.Data;
//using Pokemon.Dtos;
//using Pokemon.Models;

//namespace Pokemon.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PokemonController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public PokemonController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpGet("pokemon")]
//        public async Task<IActionResult> GetAllPokemon()
//        {
//            var pokemonList = await _context.PokemonData
//                .Include(p => p.Picture)
//                .Include(p => p.Trainer)
//                .Include(p => p.PokemonRegions)
//                .ThenInclude(pr => pr.Region)
//                .Include(p => p.Movesets)
//                .ThenInclude(ms => ms.Move)
//                .Include(p => p.EvolutionGroup)
//                .ToListAsync();

//            var pokemonDtos = pokemonList.Select(p => new PokemonDataDto
//            {
//                PokemonID = p.PokemonID,
//                PokemonName = p.PokemonName,
//                PictureURL = p.Picture?.PictureURL,
//                Trainer = p.Trainer != null ? new TrainerDto
//                {
//                    TrainerName = p.Trainer.TrainerName,
//                } : null,
//                PokemonRegions = p.PokemonRegions.Select(pr => new PokemonRegionDto
//                {
//                    RegionName = pr.Region.RegionName
//                }).ToList(),
//                Movesets = p.Movesets.Select(ms => new MovesetDto
//                {
//                    MoveName = ms.Move.MoveName
//                }).ToList(),
//                EvolutionGroup = p.EvolutionGroup != null ? new EvolutionGroupDto
//                {
//                    EvolutionGroupName = p.EvolutionGroup.EvolutionGroupName
//                } : null
//            }).ToList();

//            return Ok(pokemonDtos);
//        }

//        [HttpPut("pokemon/{id}")]
//        public async Task<IActionResult> EditPokemon(int id, [FromBody] UpdatePokemonDto updatePokemonDto)
//        {
//            var pokemon = await _context.PokemonData.FindAsync(id);

//            if (pokemon == null)
//            {
//                return NotFound("Pokemon not found.");
//            }

//            pokemon.PokemonName = updatePokemonDto.PokemonName;
//            pokemon.TrainerID = updatePokemonDto.TrainerID;
//            pokemon.PictureID = updatePokemonDto.PictureID;
//            pokemon.EvolutionGroupID = updatePokemonDto.EvolutionGroupID;

//            await _context.SaveChangesAsync();

//            return NoContent();
//        }
//        [HttpDelete("pokemon/{id}")]
//        public async Task<IActionResult> DeletePokemon(int id)
//        {
//            var pokemon = await _context.PokemonData.FindAsync(id);

//            if (pokemon == null)
//            {
//                return NotFound("Pokemon not found.");
//            }
//            _context.PokemonData.Remove(pokemon);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//    }
//}
