using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class Region
    {
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<PokemonRegion> PokemonRegions { get; set; }
    }

}
