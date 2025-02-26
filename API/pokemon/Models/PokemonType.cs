using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class PokemonType
    {
        public int TypesPokemonID { get; set; }
        public int TypesPokeTypeID { get; set; } 

        public virtual PokemonData Pokemon { get; set; }
        public virtual PokeType PokeType { get; set; } 
    }

}
