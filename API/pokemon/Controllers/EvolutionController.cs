using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;

namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvolutionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EvolutionController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvolutionStageDto>>> GetEvolutionStages()
        {
            var evostages = await _context.EvolutionStages
                .ProjectTo<EvolutionStageDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(evostages);
        }
    }
}
