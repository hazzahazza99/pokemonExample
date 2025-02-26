using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class PokeType
    {
        [Key]
        public int PokeTypeID { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<PokemonType> PokemonTypes { get; set; }
        public virtual ICollection<Move> Moves { get; set; }
    }
}
