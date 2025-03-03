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
    public class RegionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RegionController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetAllRegions()
        {
            var regions = await _context.Regions
                .ProjectTo<RegionDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(regions);
        }
    }
}
