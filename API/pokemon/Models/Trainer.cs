using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public int? TrainerAge { get; set; }
        public string TrainerBadge { get; set; }
        public bool IsGymLeader { get; set; }
        public virtual ICollection<PokemonData> Pokemons { get; set; }
    }

}
