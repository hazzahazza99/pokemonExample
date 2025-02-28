namespace Pokemon.Dtos
{
    public class PokemonDto
    {
        public int PokemonID { get; set; }
        public string PokemonName { get; set; }
        public int PokemonPictureID { get; set; }
        public int? EvolutionGroupID { get; set; }
        public int? PokemonTrainerID { get; set; }
    }
}
