using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class PokemonData
    {
        [Key]
        public int PokemonID { get; set; }
        public string PokemonName { get; set; }
        public int? PokemonPictureID { get; set; }
        public int? EvolutionGroupID { get; set; }
        public int? PokemonTrainerID { get; set; }

        public virtual Picture? PokemonPicture { get; set; }
        public virtual Trainer? Trainer { get; set; }
        public virtual EvolutionGroup? EvolutionGroup { get; set; }
        public virtual ICollection<PokemonType> PokemonTypes { get; set; }
        public virtual ICollection<Moveset> Moves { get; set; }
        public virtual ICollection<PokemonRegion> Regions { get; set; }
        public virtual ICollection<EvolutionStage> EvolutionStages { get; set; }

    }
}
