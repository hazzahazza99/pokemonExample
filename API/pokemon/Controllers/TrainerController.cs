using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly DataContext _context;

        public TrainerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("trainers")]
        public async Task<IActionResult> GetAllTrainers()
        {
            var trainerList = await _context.Trainers
                .Include(t => t.Pokemons)
                .ToListAsync();

            var trainerDtos = trainerList.Select(t => new TrainerDto
            {
                TrainerID = t.TrainerID,
                TrainerName = t.TrainerName,
                TrainerAge = t.TrainerAge,
                TrainerBadge = t.TrainerBadge,
                IsGymLeader = t.IsGymLeader
            }).ToList();

            return Ok(trainerDtos);
        }
        [HttpPost("trainers")]
        public async Task<IActionResult> AddTrainer([FromBody] CreateTrainerDto createTrainerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTrainer = new Trainer
            {
                TrainerName = createTrainerDto.TrainerName,
                TrainerAge = createTrainerDto.TrainerAge,
                TrainerBadge = createTrainerDto.TrainerBadge,
                IsGymLeader = createTrainerDto.IsGymLeader
            };

            _context.Trainers.Add(newTrainer);
            await _context.SaveChangesAsync();

            var newTrainerDto = new TrainerDto
            {
                TrainerID = newTrainer.TrainerID,
                TrainerName = newTrainer.TrainerName,
                TrainerAge = newTrainer.TrainerAge,
                TrainerBadge = newTrainer.TrainerBadge,
                IsGymLeader = newTrainer.IsGymLeader
            };

            return CreatedAtAction(nameof(GetAllTrainers), new { id = newTrainer.TrainerID }, newTrainerDto);
        }
        [HttpDelete("trainers/{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);

            if (trainer == null)
            {
                return NotFound("Trainer not found.");
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
