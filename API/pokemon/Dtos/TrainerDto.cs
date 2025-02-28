using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class TrainerDto
    {
        public int TrainerID { get; set; }
        public required string TrainerName { get; set; }
        public int TrainerAge { get; set; }
        public int TrainerBadge { get; set; }
        public bool TrainerIsGymLeader { get; set; }
        public int? TrainerPhotoID { get; set; }
    }
}
