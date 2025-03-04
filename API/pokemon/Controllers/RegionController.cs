using AutoMapper;
using AutoMapper.QueryableExtensions;
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


        [HttpPost]
        public async Task<ActionResult<RegionDto>> CreateRegion(RegionDto regionDto)
        {
            if (await _context.Regions.AnyAsync(m => m.RegionName == regionDto.RegionName))
                return BadRequest("Region with this name already exists");

            var region = _mapper.Map<Region>(regionDto);

            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllRegions), _mapper.Map<RegionDto>(region));
        }
    }
}

