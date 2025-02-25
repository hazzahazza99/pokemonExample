namespace Pokemon.Dtos
{
    public class UpdatePokemonDto
    {
        public string PokemonName { get; set; }
        public int TrainerID { get; set; }
        public int? PictureID { get; set; }
        public int EvolutionGroupID { get; set; }
    }


}
