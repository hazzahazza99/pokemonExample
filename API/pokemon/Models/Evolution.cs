using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class Evolution
    {
        [Key]
        public int EvolutionID { get; set; }
        public int StageNumber { get; set; }
        public int EvolutionGroupID { get; set; }
        public int PokemonID { get; set; }

        public virtual EvolutionGroup EvolutionGroup { get; set; }
        public virtual PokemonData Pokemon { get; set; }
    }
}
