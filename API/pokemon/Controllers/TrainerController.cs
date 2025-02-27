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
    public class TrainerController : ControllerBase
    {
        private readonly DataContext _context;

        public TrainerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainerDto>>> GetTrainers()
        {
            var trainers = await _context.Trainers
                .Select(t => new TrainerDto
                {
                    TrainerID = t.TrainerID,
                    TrainerName = t.TrainerName,
                    TrainerAge = t.TrainerAge,
                    TrainerBadge = t.TrainerBadge,
                    TrainerIsGymLeader = t.TrainerIsGymLeader,
                    TrainerPhotoID = t.TrainerPhotoID
                })
                .ToListAsync();

            return trainers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerDto>> GetTrainer(int id)
        {
            var trainer = await _context.Trainers
                .Where(t => t.TrainerID == id)
                .Select(t => new TrainerDto
                {
                    TrainerID = t.TrainerID,
                    TrainerName = t.TrainerName,
                    TrainerAge = t.TrainerAge,
                    TrainerBadge = t.TrainerBadge,
                    TrainerIsGymLeader = t.TrainerIsGymLeader,
                    TrainerPhotoID = t.TrainerPhotoID
                })
                .FirstOrDefaultAsync();

            if (trainer == null)
            {
                return NotFound();
            }

            return trainer;
        }

        [HttpPost]
        public async Task<ActionResult<TrainerDto>> PostTrainer(TrainerDto trainerDto)
        {
            var trainer = new Trainer
            {
                TrainerName = trainerDto.TrainerName,
                TrainerAge = trainerDto.TrainerAge,
                TrainerBadge = trainerDto.TrainerBadge,
                TrainerIsGymLeader = trainerDto.TrainerIsGymLeader,
                TrainerPhotoID = trainerDto.TrainerPhotoID
            };

            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();

            trainerDto.TrainerID = trainer.TrainerID;

            return CreatedAtAction("GetTrainer", new { id = trainer.TrainerID }, trainerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, TrainerDto trainerDto)
        {
            if (id != trainerDto.TrainerID)
            {
                return BadRequest();
            }

            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            trainer.TrainerName = trainerDto.TrainerName;
            trainer.TrainerAge = trainerDto.TrainerAge;
            trainer.TrainerBadge = trainerDto.TrainerBadge;
            trainer.TrainerIsGymLeader = trainerDto.TrainerIsGymLeader;
            trainer.TrainerPhotoID = trainerDto.TrainerPhotoID;

            _context.Entry(trainer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}