using Pokemon.Dtos;
using Pokemon.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Services.Interfaces;

namespace Pokemon.Services
{
    public class RegionService : IRegionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RegionService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RegionDto>> GetAllRegions()
        {
            var regions = await _context.Regions
                .AsNoTracking()
                .ProjectTo<RegionDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return regions;
        }
    }
}