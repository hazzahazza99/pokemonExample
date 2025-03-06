using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class EvolutionStage
    {
        [Key]
        public int PokemonID { get; set; }
        public int GroupID { get; set; }
        public int StageOrder { get; set; }

        public virtual EvolutionGroup EvolutionGroup { get; set; }
        [ForeignKey("PokemonID")]
        public virtual PokemonData Pokemon { get; set; }
    }
}
