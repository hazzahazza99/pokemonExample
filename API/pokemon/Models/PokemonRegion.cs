using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class PokemonRegion
    {
        public int RegionsPokemonID { get; set; }
        public int RegionsRegionID { get; set; }

        public virtual PokemonData Pokemon { get; set; }
        public virtual Region Region { get; set; }
    }

}
