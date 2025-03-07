using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Dtos;
using Pokemon.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public class TypeService : ITypeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TypeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PokeTypeDto>> GetAllTypes()
        {
            var types = await _context.PokeTypes
                .AsNoTracking()
                .ProjectTo<PokeTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return types;
        }
    }
}