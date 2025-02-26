using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public int TrainerAge { get; set; }
        public int TrainerBadge { get; set; }
        public bool TrainerIsGymLeader { get; set; }
        public int? TrainerPhotoID { get; set; }

        public virtual Picture TrainerPhoto { get; set; }
        public virtual ICollection<PokemonData> Pokemon { get; set; }
    }

}
