using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class EvolutionStage
    {
        public int GroupID { get; set; }
        public int StageOrder { get; set; }
        public int PokemonID { get; set; }

        public virtual EvolutionGroup EvolutionGroup { get; set; }
        public virtual PokemonData Pokemon { get; set; }
    }
}
