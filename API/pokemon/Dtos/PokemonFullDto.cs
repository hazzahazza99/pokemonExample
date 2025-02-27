using Pokemon.Models;

namespace Pokemon.Dtos
{
    public class PokemonFullDto
    {
        public int PokemonID { get; set; }
        public string PokemonName { get; set; }
        public Picture? PokemonPicture { get; set; }

        public TrainerDto? Trainer { get; set; }
        public List<string> Types { get; set; }
        public List<string> Moves { get; set; }
        public List<string> Regions { get; set; }
        public EvolutionGroupDto? EvolutionGroup { get; set; }
    }



}
