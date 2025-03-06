using Pokemon.Dtos;
using Pokemon.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public class TypeService : ITypeService
    {
        // TEMPORARY MOCK DATA
        private readonly List<PokeTypeDto> _mockTypes = new()
    {
        new PokeTypeDto { PokeTypeID = 1, TypeName = "Fire" },
        new PokeTypeDto { PokeTypeID = 2, TypeName = "Water" }
    };

        public async Task<List<PokeTypeDto>> GetAllTypes()
        {
            // For testing, return mock data first
            return await Task.FromResult(_mockTypes);

            // Later replace with actual database code:
            // return await _context.PokemonTypes.ToListAsync();
        }
    }
}