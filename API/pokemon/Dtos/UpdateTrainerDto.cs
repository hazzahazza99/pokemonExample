namespace Pokemon.Dtos
{
    public class UpdateTrainerDto
    {
        public string TrainerName { get; set; }
        public int? TrainerAge { get; set; }
        public string TrainerBadge { get; set; }
        public bool IsGymLeader { get; set; }
    }


}
