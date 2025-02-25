using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class PokemonData
    {
        [Key]
        public int PokemonID { get; set; }
        public string PokemonName { get; set; }
        public int? TrainerID { get; set; }
        public int? PictureID { get; set; }
        public int? EvolutionGroupID { get; set; }

        public virtual Picture Picture { get; set; }
        public virtual EvolutionGroup EvolutionGroup { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<PokemonRegion> PokemonRegions { get; set; }
        public virtual ICollection<Moveset> Movesets { get; set; }
    }

}
