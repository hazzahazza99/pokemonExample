using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class PokemonRegion
    {
        [Key]
        public int PokemonID { get; set; }
        public int RegionID { get; set; }

        public virtual PokemonData Pokemon { get; set; }
        public virtual Region Region { get; set; }
    }

}
