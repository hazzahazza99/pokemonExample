using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class Moveset
    {
        public int MovesetPokemonID { get; set; }
        public int MovesetMoveID { get; set; }

        public virtual PokemonData Pokemon { get; set; }
        public virtual Move Move { get; set; }
    }
}
