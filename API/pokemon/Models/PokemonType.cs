using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class PokemonType
    {
        [Key]
        public int PokemonID { get; set; }
        public int TypeListID { get; set; }

        public virtual PokemonData Pokemon { get; set; }
        public virtual TypeList TypeList { get; set; }
    }

}
