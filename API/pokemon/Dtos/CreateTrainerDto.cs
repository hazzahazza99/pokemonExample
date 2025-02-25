namespace Pokemon.Dtos
{
    public class CreateTrainerDto
    {
        public string TrainerName { get; set; }
        public int? TrainerAge { get; set; }
        public string TrainerBadge { get; set; }
        public bool IsGymLeader { get; set; }
    }

}
