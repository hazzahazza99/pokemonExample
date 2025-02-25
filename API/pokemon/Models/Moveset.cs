using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class Moveset
    {
        public int PokemonID { get; set; }
        public int MoveID { get; set; }

        public virtual PokemonData Pokemon { get; set; }
        public virtual Move Move { get; set; }
    }
}
