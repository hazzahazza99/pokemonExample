using Pokemon.Dtos;
using Pokemon.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public class MoveService : IMoveService
    {
        private readonly List<MoveDto> _mockMoves = new()
    {
        new MoveDto
        {
            MoveID = 1,
            MoveName = "Ember",
            MovePower = 40,
            MovePP = 25,
            MovePokeTypeID = 1,
            MovePokeType = new PokeTypeDto
            {
                PokeTypeID = 1,
                TypeName = "Fire"
            }
        }
    };

        public async Task<List<MoveDto>> GetAllMoves()
        {
            return await Task.FromResult(_mockMoves);
        }
    }
}