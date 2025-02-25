using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class TrainerDto
    {
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public int? TrainerAge { get; set; }
        public string TrainerBadge { get; set; }
        public bool IsGymLeader { get; set; }
    }
}
