using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class EvolutionGroup
    {
        public int EvolutionGroupID { get; set; }
        public virtual ICollection<PokemonData> PokemonData { get; set; }
        public virtual ICollection<EvolutionStage> EvolutionStages { get; set; }
    }
}